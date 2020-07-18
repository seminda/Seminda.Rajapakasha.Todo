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
        private readonly IUpdateTaskCommand _updateTaskCommand;
        private readonly IDeleteTaskCommand _deleteTaskCommand;
        private readonly IGetTaskQuery _getTaskQuery;
        private readonly IGetTaskListQuery _getTaskListQuery;

        public TodoController(ICreateTaskCommand createTaskCommand, IUpdateTaskCommand updateTaskCommand,
            IDeleteTaskCommand deleteTaskCommand, IGetTaskQuery getTaskQuery, IGetTaskListQuery getTaskListQuery)
        {
            _createTaskCommand = createTaskCommand;
            _updateTaskCommand = updateTaskCommand;
            _deleteTaskCommand = deleteTaskCommand;
            _getTaskQuery = getTaskQuery;
            _getTaskListQuery = getTaskListQuery;
        }

        [HttpPost(Name = "CreateTodo")]
        public async Task<IActionResult> CreateTodo(CreateTodoItemDto todoItem)
        {
            var result = await _createTaskCommand.Execute(todoItem);

            return OkOrFailure(result, HttpStatusCode.Created);
        }

        [HttpPut("{id}", Name = "UpdateTodo")]
        public async Task<IActionResult> UpdateTodo([FromRoute] long id, UpdateTodoItemDto todoItem)
        {
            var result = await _updateTaskCommand.Execute(id, todoItem);

            return OkOrFailure(result);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> GetTodo([FromRoute] long id)
        {
            var result = await _getTaskQuery.Execute(id);

            return OkOrFailure(result);
        }

        [HttpGet(Name = "GetTodoList")]
        public async Task<IActionResult> GetTodoList()
        {
            var result = await _getTaskListQuery.Execute();

            return OkOrFailure(result);
        }

        [HttpDelete("{id}", Name = "DeleteTodo")]
        public async Task<IActionResult> DeleteTodo([FromRoute] long id)
        {
            var result = await _deleteTaskCommand.Execute(id);

            return OkOrFailure(result);
        }

        private IActionResult OkOrFailure<TResponse>(Result<TResponse> result,
            HttpStatusCode responseStatus = HttpStatusCode.OK, string createdUri = "")
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

        private IActionResult Failure(ErrorCode? errorCategory)
        {
            switch (errorCategory)
            {
                case ErrorCode.NotFound:
                    return NotFound();
                default:
                    return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }
    }
}