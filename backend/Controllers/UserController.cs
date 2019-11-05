using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
      _logger = logger;
      _userRepository = userRepository;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
      return _userRepository.GetUsers().ToList();
    }

    [HttpPost]
    public void Post(User user)
    {
      _userRepository.CreateUser(user);
    }
  }
}
