using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.GraphQL.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(query => query.Posts(default, default))
                .Type<ListType<PostType>>()
                .Argument("first", desc => desc.DefaultValue(10))
                .Argument("offset", desc => desc.DefaultValue(0));

            descriptor.Field(query => query.Comments(default, default))
                .Type<ListType<CommentType>>()
                .Argument("first", desc => desc.DefaultValue(10))
                .Argument("offset", desc => desc.DefaultValue(0));
        }
    }
}
