using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seminda.Rajapaksha.Todo.Api.Application.Command;
using Seminda.Rajapaksha.Todo.Api.Application.Common;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Application.Query;

namespace Seminda.Rajapaksha.Todo.Api.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ICreateTaskCommand _createTaskCommand;
        private readonly IGetTaskQuery _getTaskQuery;

        public TodoController(ICreateTaskCommand createTaskCommand, IGetTaskQuery getTaskQuery)
        {
            _createTaskCommand = createTaskCommand;
            _getTaskQuery = getTaskQuery;
        }

        [HttpPost(Name = "CreateTodo")]
        public async Task<IActionResult> CreateTodo(CreateTodoItemDto todoItem)
        {
            var result = await _createTaskCommand.Execute(todoItem);

            return OkOrFailure(result, HttpStatusCode.Created);
        }

        private IActionResult OkOrFailure<TResponse>(Result<TResponse> result, HttpStatusCode responseStatus = HttpStatusCode.OK, string createdUri = "")
        {
            if (result.IsSuccess())
            {
                switch (responseStatus)
                {
                    case HttpStatusCode.Created:
                        return Created(createdUri, result.Data);
                    default:
                        return Ok(result.Data);
                }
            }
            return Failure(result.ErrorCode);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> GetTodo([FromRoute]long id)
        {
            var result = await _getTaskQuery.Execute(id);

            return OkOrFailure(result);
        }

        private IActionResult Failure(ErrorCode? errorCategory)
        {
            switch (errorCategory)
            {
                case ErrorCode.NotFound:
                    return NotFound();
                default:
                    return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}