using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Seminda.Rajapaksha.Todo.Api.Application.Model;

namespace Seminda.Rajapaksha.Todo.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot()
        {
            var id = 132395363728231900;
            
            var links = new List<LinkDto>();

            links.Add(
                new LinkDto(Url.Link("GetTodo", new { id }),
                    "get_todo",
                    "GET"));
            links.Add(
                new LinkDto(Url.Link("GetTodoList", new { }),
                    "get_todo_list",
                    "GET"));

            links.Add(
                new LinkDto(Url.Link("CreateTodo", new { }),
                    "create_todo",
                    "POST"));

            links.Add(
                new LinkDto(Url.Link("UpdateTodo", new { id }),
                    "update_todo",
                    "PUT"));

            links.Add(
                new LinkDto(Url.Link("DeleteTodo", new { id }),
                    "delete_todo",
                    "DELETE"));

            return Ok(links);

        }
    }
}