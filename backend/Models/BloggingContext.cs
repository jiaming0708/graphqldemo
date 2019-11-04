using System;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
  public class BloggingContext : DbContext
  {
    public BloggingContext(DbContextOptions<BloggingContext> options)
      : base(options) { }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
