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

    public void CreatePost(Post post)
    {
      _context.Posts.Add(post);
      _context.SaveChanges();
    }
  }
}
