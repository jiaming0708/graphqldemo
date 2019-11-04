using System;
using System.Linq;
using backend.Models;

namespace backend.Repositories
{
  public class PostRepository : IPostRepository
  {
    private readonly BloggingContext _context;
    public PostRepository(BloggingContext context)
    {
      _context = context;
    }

    public Post GetPostById(int id)
    {
      return _context.Posts.FirstOrDefault(p => p.Id == id);
    }

    public IQueryable<Post> GetPosts()
    {
      return _context.Posts;
    }
  }
}
