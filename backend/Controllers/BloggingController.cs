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
  public class BloggingController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPostRepository _postRepository;

    public BloggingController(ILogger<WeatherForecastController> logger, IPostRepository postRepository)
    {
      _logger = logger;
      _postRepository = postRepository;
    }

    [HttpGet]
    public IEnumerable<Post> Get()
    {
      return _postRepository.GetPosts().ToList();
    }
  }
}
