using Entities = Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Jbuisson.Blog.Core.Query
{
    public class CommentQuery : Query<Comment, Entities.Comment>
    {
        public CommentQuery(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public override IQuery<Comment> For<TRelation>(int id)
        {
            if (typeof(TRelation) == typeof(Post))
                m_query = m_query.Where(comment => comment.Id_Post == id);

            return this;
        }

        protected override Expression<Func<Entities.Comment, Comment>> Mapper()
        {
            return comment => new Comment
            {
                Id = comment.Id,
                Author = comment.User.Name,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
            };
        }
    }
}
