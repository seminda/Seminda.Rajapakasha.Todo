using System.Collections.Generic;
using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;

namespace Seminda.Rajapaksha.Todo.Api.Application.Query
{
   public  interface IGetTaskListQuery
    {
        Task<Result<List<TodoItemDto>>> Execute();
    }
}
