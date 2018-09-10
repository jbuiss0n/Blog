using Entities = Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Query
{
    public class PostQuery : Query<Post, Entities.Post>
    {
        public PostQuery(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
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
