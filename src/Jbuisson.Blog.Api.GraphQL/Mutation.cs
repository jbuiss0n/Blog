using Jbuisson.Blog.Core.Command;
using Jbuisson.Blog.Core.Command.CommentCommands;
using Jbuisson.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.GraphQL
{
    public class Mutation
    {
        private readonly ICommandResolver m_resolver;

        public Mutation(ICommandResolver resolver)
        {
            m_resolver = resolver;
        }

        public CommentCreateResult CreateComment(Post post, CommentCreateCommand command)
        {
            return m_resolver.Publish<CommentCreateCommand, CommentCreateResult>(command).Result;
        }
    }
}
