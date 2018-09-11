using Entities = Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Jbuisson.Blog.Core.Query
{
    public class PostQuery : Query<Post, Entities.Post>, IPostQuery
    {
        public PostQuery(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public virtual async Task<Post> Find(string title)
        {
            return await m_query
                .Where(entity => entity.CanonicalTitle == title)
                .Select(Mapper())
                .FirstOrDefaultAsync();
        }

        protected override Expression<Func<Entities.Post, Post>> Mapper()
        {
            return post => new Post
            {
                Id = post.Id,
                Title = post.Title,
                CanonicalTitle = post.CanonicalTitle,
                Author = post.User.Name,
                Preview = post.Preview,
                Content = post.Content,
                CommentsCount = post.CommentsCount,
                ViewsCount = post.ViewsCount,
                PublishedAt = post.PublishedAt,
                Id_LastComment = post.Id_LastComment,
                LastCommentedAt = post.LastCommentedAt,
            };
        }
    }
}
