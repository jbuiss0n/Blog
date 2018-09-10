using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Data.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Command.CommentCommands
{
    public class CommentCreateHandler : ICommandHandler<CommentCreateCommand, CommentCreateResult>
    {
        private readonly EntityContext m_entityContext;

        public CommentCreateHandler(IServiceProvider serviceProvider)
        {
            m_entityContext = serviceProvider.GetService<EntityContext>();
        }

        public async Task<CommentCreateResult> Execute(CommentCreateCommand command, CommentCreateResult result)
        {
            var now = DateTime.Now;
            var comment = new Comment
            {
                CreatedAt = now,
            };

            m_entityContext.Add(comment);
            await m_entityContext.SaveChangesAsync();

            result.Created = comment.Id;
            result.CreatedAt = comment.CreatedAt;

            return result;
        }
    }
}
