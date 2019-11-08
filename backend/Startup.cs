using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.GraphModels;
using backend.Models;
using backend.Repositories;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // repository
      services.AddScoped<IPostRepository, PostRepository>();
      services.AddScoped<IUserRepository, UserRepostiory>();
      services.AddDbContext<BloggingContext>(options => options.UseSqlite(Configuration.GetConnectionString("Database")));

      // graphql
      services.AddTransient<PostType>();
      services.AddTransient<UserType>();
      services.AddScoped<BloggingQuery>();
      services.AddScoped<ISchema, BloggingSchema>();
      services.AddHttpContextAccessor();
      services.AddGraphQL(_ =>
      {
        _.EnableMetrics = true;
        _.ExposeExceptions = true;
      });

      services.AddControllers();

      services.AddCors(options =>
      {
        options.AddPolicy("cors",
          builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
      });

      // [reference for this issue](https://stackoverflow.com/questions/47735133/asp-net-core-synchronous-operations-are-disallowed-call-writeasync-or-set-all)
      services.Configure<KestrelServerOptions>(options =>
      {
        options.AllowSynchronousIO = true;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors("cors");

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseGraphQL<ISchema>();
    }
  }
}
