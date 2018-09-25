using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Jbuisson.Blog.Core.Command;
using Jbuisson.Blog.Core.Command.CommentCommands;
using Jbuisson.Blog.Core.Command.PostCommands;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using Microsoft.AspNetCore.Mvc;

namespace Jbuisson.Blog.Rest.Controllers
{
    [ApiController]
    [Route("posts/{post}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentQuery m_query;
        private readonly ICommandResolver m_commandResolver;

        public CommentsController(ICommentQuery query, ICommandResolver commandResolver)
        {
            m_query = query;
            m_commandResolver = commandResolver;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Comment>>> Get(string post, int limit = 10, int offset = 0)
        {
            return (await m_query.WithPost(post).Fetch(limit, offset)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(string post, int id)
        {
            return await m_query.WithPost(post).Find(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(int post, [FromBody] CommentCreateCommand command)
        {
            if (post != command.Id_Post)
                return NotFound();

            var result = await m_commandResolver.Publish<CommentCreateCommand, CommentCreateResult>(command);

            if (result.Exception != null)
                return StatusCode((int)HttpStatusCode.InternalServerError);

            if (result.ValidationErrors.Any())
                return BadRequest(result.ValidationErrors);

            return CreatedAtAction(nameof(Get), new { post, id = result.Created }, result);
        }
    }
}
