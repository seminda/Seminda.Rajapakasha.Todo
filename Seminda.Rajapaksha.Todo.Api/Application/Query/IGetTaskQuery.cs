using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;

namespace Seminda.Rajapaksha.Todo.Api.Application.Query
{
    public interface IGetTaskQuery
    {
        Task<Result<TodoItemDto>> Execute(long id);
    }
}
