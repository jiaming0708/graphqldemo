using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace backend.GraphModels
{
  public class BloggingSchema : Schema
  {
    public BloggingSchema(IServiceProvider provider)
            : base(provider)
    {
      Query = provider.GetRequiredService<BloggingQuery>();
    }
  }
}
