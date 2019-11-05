using System;
using System.Linq;
using backend.Models;

namespace backend.Repositories
{
  public class UserRepostiory : IUserRepository
  {
    private readonly BloggingContext _context;

    public UserRepostiory(BloggingContext context)
    {
      _context = context;
    }

    public User GetUserById(int id)
    {
      return _context.Users.FirstOrDefault(p => p.Id == id);
    }

    public IQueryable<User> GetUsers()
    {
      return _context.Users;
    }

    public void CreateUser(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }
  }
}
