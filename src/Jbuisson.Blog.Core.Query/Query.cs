using Entities = Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Jbuisson.Blog.Data.EntityFramework;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Jbuisson.Blog.Core.Query
{
    public abstract class Query<TDomain, TEntity> : IQuery<TDomain>
        where TDomain : IDomain
        where TEntity : Entities.Entity
    {
        protected IQueryable<TEntity> m_query;

        public Query(IServiceProvider serviceProvider)
        {
            m_query = serviceProvider.GetService<EntityContext>().Set<TEntity>();
        }

        public virtual IQuery<TDomain> For<TRelation>(int id)
            where TRelation : IDomain
        {
            if (typeof(TRelation) == typeof(TDomain))
                m_query = m_query.Where(entity => entity.Id == id);

            return this;
        }

        public virtual async Task<int> Count()
        {
            return await m_query.CountAsync();
        }

        public virtual async Task<bool> Exists()
        {
            return await m_query.AnyAsync();
        }

        public virtual async Task<TDomain> Find(int id)
        {
            return await m_query
                .Where(entity => entity.Id == id)
                .Select(Mapper())
                .FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<TDomain>> Fetch(int limit, int offset)
        {
            return await m_query
                .Skip(offset)
                .Take(limit)
                .Select(Mapper())
                .ToListAsync();
        }

        protected abstract Expression<Func<TEntity, TDomain>> Mapper();
    }
}
