using Jbuisson.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Query
{
    public interface IQuery<TDomain>
        where TDomain : IDomain
    {
        Task<bool> Exists();

        Task<int> Count();

        Task<TDomain> Find(int id);

        Task<ICollection<TDomain>> Fetch(int limit, int offset);

        IQuery<TDomain> For<TRelation>(int id) where TRelation : IDomain;
    }
}
