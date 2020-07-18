using System.Collections.Generic;
using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;

namespace Seminda.Rajapaksha.Todo.Api.Application.Query
{
    public class GetTaskListQuery : IGetTaskListQuery
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskListQuery(ITaskRepository repository)
        {
            _taskRepository = repository;
        }
        
        public Task<Result<List<TodoItemDto>>> Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
