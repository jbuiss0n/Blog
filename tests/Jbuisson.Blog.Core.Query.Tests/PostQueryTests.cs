using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.Entities;
using Jbuisson.Blog.Data.EntityFramework;
using Jbuisson.Blog.Data.EntityFramework.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Xunit;

namespace Jbuisson.Blog.Core.Query.Tests
{
    public class PostQueryTests
    {
        private readonly PostQuery m_subject;
        private readonly EntityContext m_repository;

        public PostQueryTests()
        {
            m_repository = new DesignTimeDbContextFactory().CreateDbContext(new string[] { });
            m_subject = new PostQuery(new DummyServiceProvider(m_repository));
        }

        [Fact]
        public void Find()
        {
            m_repository.Add(new Post { Id = 1 });
            m_repository.Add(new Post { Id = 2 });
            m_repository.SaveChanges();

            var actual = m_subject.Find(1);

            Assert.NotNull(actual);
            Assert.Equal(1, actual.Id);
        }
    }
}
