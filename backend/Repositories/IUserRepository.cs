using System;
using System.Linq;
using backend.Models;

namespace backend.Repositories
{
  public interface IUserRepository
  {
    public User GetUserById(int id);
    public IQueryable<User> GetUsers();
  }
}
