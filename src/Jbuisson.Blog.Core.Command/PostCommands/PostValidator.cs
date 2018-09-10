using Jbuisson.Blog.Data;
using Jbuisson.Blog.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class PostValidator
        : ICommandValidator<PostCreateCommand, PostCreateResult>
        , ICommandValidator<PostEditCommand, PostEditResult>
        , ICommandValidator<PostDeleteCommand, PostDeleteResult>
    {
        private readonly EntityContext m_entityContext;

        public PostValidator(IServiceProvider serviceProvider)
        {
            m_entityContext = serviceProvider.GetService<EntityContext>();
        }

        public async Task<PostCreateResult> Validate(PostCreateCommand command)
        {
            var result = new PostCreateResult();

            if (!await m_entityContext.Posts.AnyAsync(post => post.Title == command.Title))
                result.ValidationErrors.Add(new ValidationError(nameof(command.Title), $"Invalid Post '{command.Title}'"));

            return result;
        }

        public async Task<PostEditResult> Validate(PostEditCommand command)
        {
            var result = new PostEditResult();

            if (!await m_entityContext.Posts.AnyAsync(post => post.Id == command.Id))
                result.ValidationErrors.Add(new ValidationError(nameof(command.Id), $"Invalid Post '{command.Id}'"));

            return result;
        }

        public async Task<PostDeleteResult> Validate(PostDeleteCommand command)
        {
            var result = new PostDeleteResult();

            if (!await m_entityContext.Posts.AnyAsync(post => post.Id == command.Id))
                result.ValidationErrors.Add(new ValidationError(nameof(command.Id), $"Invalid Post '{command.Id}'"));

            return result;
        }
    }
}
