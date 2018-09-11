using HotChocolate;
using HotChocolate.Resolvers;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.GraphQL
{
    public class Query
    {
        private readonly IPostQuery m_postQuery;
        private readonly IQuery<Comment> m_commentQuery;

        public Query(IPostQuery postQuery, IQuery<Comment> commentQuery)
        {
            m_postQuery = postQuery;
            m_commentQuery = commentQuery;
        }

        public List<Post> Posts(int first, int offset)
        {
            return m_postQuery.Fetch(first, offset).Result.ToList();
        }

        public Post Post(string title)
        {
            return m_postQuery.Find(title).Result;
        }

        public List<Comment> Comments(int first, int offset)
        {
            return m_commentQuery.Fetch(first, offset).Result.ToList();
        }

        public Comment Comment(int id)
        {
            return m_commentQuery.Find(id).Result;
        }
    }
}
