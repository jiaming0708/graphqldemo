using System;
namespace backend.Models
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; }
  }
}
