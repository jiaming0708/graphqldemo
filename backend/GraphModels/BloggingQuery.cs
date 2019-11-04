using System;
using backend.Repositories;
using GraphQL.Types;

namespace backend.GraphModels
{
  public class BloggingQuery : ObjectGraphType
  {
    public BloggingQuery(IPostRepository postRepository, IUserRepository userRepository)
    {
      Field<ListGraphType<PostType>>(
        "posts",
        arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "post id" }),
        resolve: context => {
          var id = context.GetArgument<int>("id");
          if (id == 0)
          {
            return postRepository.GetPosts();
          }

          return postRepository.GetPostById(id);
        }
        );

      Field<ListGraphType<UserType>>(
        "users",
        arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id", Description = "user id" }),
        resolve: context =>
        {
          var id = context.GetArgument<int>("id");
          if (id == 0)
          {
            return userRepository.GetUsers();
          }

          return userRepository.GetUserById(id);
        }
        );
    }
  }
}
