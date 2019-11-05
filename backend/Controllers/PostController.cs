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
  public class PostController : ControllerBase
  {
    private readonly ILogger<PostController> _logger;
    private readonly IPostRepository _postRepository;

    public PostController(ILogger<PostController> logger, IPostRepository postRepository)
    {
      _logger = logger;
      _postRepository = postRepository;
    }

    [HttpGet]
    public IEnumerable<Post> Get()
    {
      return _postRepository.GetPosts().ToList();
    }

    [HttpPost]
    public void CreatePost(Post post)
    {
      _postRepository.CreatePost(post);
    }
  }
}
