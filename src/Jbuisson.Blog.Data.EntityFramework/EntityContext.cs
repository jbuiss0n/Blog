using Jbuisson.Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Jbuisson.Blog.Data.EntityFramework
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(post => post.User).WithMany(user => user.Posts)
                .HasForeignKey(post => post.Id_User)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Post>()
                .HasOne(post => post.LastComment).WithMany()
                .HasForeignKey(post => post.Id_LastComment)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.User).WithMany(user => user.Comments)
                .HasForeignKey(comment => comment.Id_User)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>()
                .HasOne(comment => comment.Post).WithMany(post => post.Comments)
                .HasForeignKey(comment => comment.Id_Post)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
