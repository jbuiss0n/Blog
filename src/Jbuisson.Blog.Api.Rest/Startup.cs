using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jbuisson.Blog.Core.Command;
using Jbuisson.Blog.Core.Command.PostCommands;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.EntityFramework.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jbuisson.Blog.Rest
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
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddHttpContextAccessor();
            services.AddSingleton(Configuration);
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

            services.AddTransient<IQuery<Post>>(provider => new PostQuery(provider));
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
            app.UseMvc();
        }
    }
}
