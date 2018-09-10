using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Data.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class CommentCreateHandler : ICommandHandler<PostCreateCommand, PostCreateResult>
    {
        private readonly EntityContext m_entityContext;

        public CommentCreateHandler(IServiceProvider serviceProvider)
        {
            m_entityContext = serviceProvider.GetService<EntityContext>();
        }

        public async Task<PostCreateResult> Execute(PostCreateCommand command, PostCreateResult result)
        {
            var now = DateTime.Now;
            var post = new Post
            {
                Title = command.Title,
                CanonicalTitle = command.Title,
                PublishedAt = command.DatePublication,
                CreatedAt = now,
            };

            m_entityContext.Add(post);
            await m_entityContext.SaveChangesAsync();

            result.Created = post.Id;
            result.CreatedAt = post.CreatedAt;
            result.CanonicalTitle = post.CanonicalTitle;

            return result;
        }
    }
}
