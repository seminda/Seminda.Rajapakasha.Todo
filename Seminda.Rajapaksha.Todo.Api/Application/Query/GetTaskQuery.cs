using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;

namespace Seminda.Rajapaksha.Todo.Api.Application.Query
{
    public class GetTaskQuery:IGetTaskQuery
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskQuery(ITaskRepository repository)
        {
            _taskRepository = repository;
        }


        public Task<Result<TodoItemDto>> Execute(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
