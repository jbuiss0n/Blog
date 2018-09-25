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
    public class CommentQuery : Query<Comment, Entities.Comment>, ICommentQuery
    {
        public CommentQuery(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public virtual ICommentQuery WithPost(string title)
        {
            m_query = m_query
                .Where(comment => comment.Post.CanonicalTitle == title);

            return this;
        }

        protected override Expression<Func<Entities.Comment, Comment>> Mapper()
        {
            return comment => new Comment
            {
                Id = comment.Id,
                Id_Post = comment.Id_Post,
                Author = comment.User.Name,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
            };
        }
    }
}
