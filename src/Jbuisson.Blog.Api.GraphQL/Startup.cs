using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Jbuisson.Blog.Core.Command;
using Jbuisson.Blog.Core.Command.PostCommands;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.EntityFramework;
using Jbuisson.Blog.Data.EntityFramework.InMemory;
using Jbuisson.Blog.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jbuisson.Blog.GraphQL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddGraphQL(provider => Schema.Create(c =>
            {
                c.RegisterServiceProvider(provider);

                c.RegisterQueryType<QueryType>();
                c.RegisterType<CommentType>();
                c.RegisterType<PostType>();

                c.Options.DeveloperMode = true;
            }));

            services.AddHttpContextAccessor();
            services.AddSingleton(Configuration);
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

            services.AddTransient<IPostQuery>(provider => new PostQuery(provider));
            services.AddTransient<IQuery<Comment>>(provider => new CommentQuery(provider));
            services.AddTransient<ICommandResolver>(provider => new CommandResolver(provider));
            services.AddTransient(provider => new DesignTimeDbContextFactory().CreateDbContext(new string[] { }));

            services.AddTransient<ICommandValidator<PostCreateCommand, PostCreateResult>>(provider => new PostValidator(provider));
            services.AddTransient<ICommandHandler<PostCreateCommand, PostCreateResult>>(provider => new CommentCreateHandler(provider));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseGraphQL();

            var repository = new DesignTimeDbContextFactory().CreateDbContext(new string[] { });

            repository.Add(new Data.Entities.User
            {
                Id = 1,
                Name = "Jbuisson",
                Email = "contact@jbuisson.fr",
                CreatedAt = DateTime.Now.AddMonths(-3),
            });

            repository.Add(new Data.Entities.User
            {
                Id = 2,
                Name = "ldegracia",
                Email = "contact@ldegracia.fr",
                CreatedAt = DateTime.Now.AddMonths(-1),
            });

            repository.Add(new Data.Entities.Post
            {
                Id = 1,
                Id_User = 1,
                Title = "Test 1",
                CanonicalTitle = "test-1",
                Preview = "This blog post shows a few different types of content that's supported and styled with Bootstrap. Basic typography, images, and code are all supported.",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse in felis sit amet augue viverra condimentum. Vivamus urna nisi, cursus eget enim ut, tincidunt pulvinar mi.",
                ViewsCount = 33000000,
                CommentsCount = 2,
                PublishedAt = DateTime.Now.AddDays(-3),
            });
            repository.Add(new Data.Entities.Post
            {
                Id = 2,
                Id_User = 1,
                Title = "Test 2",
                CanonicalTitle = "test-2",
                Preview = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse in felis sit amet augue viverra condimentum. Vivamus urna nisi, cursus eget enim ut, tincidunt pulvinar mi.",
                Content = "",
                PublishedAt = DateTime.Now,
            });

            repository.Add(new Data.Entities.Comment
            {
                Id = 1,
                Id_Post = 1,
                Id_User = 1,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse in felis sit amet augue viverra condimentum. Vivamus urna nisi, cursus eget enim ut, tincidunt pulvinar mi.",
            });
            repository.Add(new Data.Entities.Comment
            {
                Id = 2,
                Id_Post = 1,
                Id_User = 2,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse in felis sit amet augue viverra condimentum. Vivamus urna nisi, cursus eget enim ut, tincidunt pulvinar mi.",
            });

            repository.SaveChanges();
        }
    }
}
