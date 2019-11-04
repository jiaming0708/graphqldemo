using System;
using backend.Models;
using backend.Repositories;
using GraphQL.Types;

namespace backend.GraphModels
{
  public class PostType : ObjectGraphType<Post>
  {
    public PostType(IUserRepository userRepository)
    {
      Field(p => p.Id).Description("Post id");
      Field(p => p.Title).Description("Post title");
      Field(p => p.Context).Description("Post context");
      Field<UserType>("Author", resolve: context => userRepository.GetUserById(context.Source.AuthorId));
    }
  }
}
