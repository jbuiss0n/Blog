using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Jbuisson.Blog.Core.Command;
using Jbuisson.Blog.Core.Command.PostCommands;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using Microsoft.AspNetCore.Mvc;

namespace Jbuisson.Blog.Rest.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private readonly IQuery<Post> m_query;
        private readonly ICommandResolver m_commandResolver;

        public PostsController(IQuery<Post> query, ICommandResolver commandResolver)
        {
            m_query = query;
            m_commandResolver = commandResolver;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Post>>> Get(int limit = 10, int offset = 0)
        {
            return (await m_query.Fetch(limit, offset)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            return await m_query.Find(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostCreateCommand command)
        {
            var result = await m_commandResolver.Publish<PostCreateCommand, PostCreateResult>(command);

            return CreateOrEditResult(result.Created, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostEditCommand command)
        {
            if (id != command.Id)
                return NotFound();

            var result = await m_commandResolver.Publish<PostEditCommand, PostEditResult>(command);

            return CreateOrEditResult(id, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new PostDeleteCommand { Id = id };
            var result = await m_commandResolver.Publish<PostDeleteCommand, PostDeleteResult>(command);

            return DeleteResult(result);
        }

        private ActionResult CreateOrEditResult(int id, CommandResult result)
        {
            return CommandResult(result, () => CreatedAtAction(nameof(Get), new { id }, result));
        }

        private ActionResult DeleteResult(CommandResult result)
        {
            return CommandResult(result, () => NoContent());
        }

        private ActionResult CommandResult(CommandResult result, Func<ActionResult> action)
        {
            if (result.Exception != null)
                return StatusCode((int)HttpStatusCode.InternalServerError);

            if (result.ValidationErrors.Any())
                return BadRequest(result.ValidationErrors);

            return action();
        }
    }
}
