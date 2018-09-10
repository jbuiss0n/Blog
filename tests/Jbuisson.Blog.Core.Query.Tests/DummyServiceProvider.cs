using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.EntityFramework;
using Jbuisson.Blog.Data.EntityFramework.InMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Query.Tests
{
    public class DummyServiceProvider : IServiceProvider
    {
        private readonly EntityContext m_repository;

        public DummyServiceProvider(EntityContext repository)
        {
            m_repository = repository;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(EntityContext))
                return m_repository;

            return null;
        }
    }
}
