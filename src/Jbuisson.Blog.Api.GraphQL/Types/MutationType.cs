using HotChocolate.Types;
using Jbuisson.Blog.Core.Command.CommentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.GraphQL.Types
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(query => query.CreateComment(default, default))
                .Argument("command", a => a.Type<NonNullType<ObjectType<CommentCreateCommand>>>());
        }
    }
}
