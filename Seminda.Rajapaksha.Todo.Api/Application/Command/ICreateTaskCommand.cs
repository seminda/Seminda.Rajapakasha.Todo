using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;

namespace Seminda.Rajapaksha.Todo.Api.Application.Command
{
    public interface ICreateTaskCommand
    {
        Task<Result<CreateTodoItemResponseDto>> Execute(CreateTodoItemDto todoItem);
    }
}
