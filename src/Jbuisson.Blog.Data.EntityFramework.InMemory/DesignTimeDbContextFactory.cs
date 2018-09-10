using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Jbuisson.Blog.Data.EntityFramework.InMemory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EntityContext>
    {
        public DesignTimeDbContextFactory()
        {
        }

        public EntityContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EntityContext>().UseInMemoryDatabase(databaseName: "Entities");

            return new EntityContext(builder.Options);
        }
    }
}
