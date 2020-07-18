using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;

namespace Seminda.Rajapaksha.Todo.Api.Application.Command
{
    public interface IUpdateTaskCommand
    {
        Task<Result<CreateTodoItemResponseDto>> Execute(long id, UpdateTodoItemDto todoItem);
    }
}
