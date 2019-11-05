using System;
using System.Linq;
using backend.Models;

namespace backend.Repositories
{
  public interface IPostRepository
  {
    public Post GetPostById(int id);
    public IQueryable<Post> GetPosts();
    public void CreatePost(Post post);
  }
}
