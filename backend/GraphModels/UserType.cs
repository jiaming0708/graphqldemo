using System;
using backend.Models;
using GraphQL.Types;

namespace backend.GraphModels
{
  public class UserType : ObjectGraphType<User>
  {
    public UserType()
    {
      Field(p => p.Id).Description("User id");
      Field(p => p.Name).Description("User name");
    }
  }
}
