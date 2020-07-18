using System.Collections.Generic;
using System.Linq;
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
        
        public async Task<Result<List<TodoItemDto>>> Execute()
        {
            var items = await _taskRepository.GetAllTasks();

            var todoItems = new List<TodoItemDto>();

            if (items != null)
            {
                todoItems.AddRange(items.Select(item => new TodoItemDto
                    { Id = item.Id, Name = item.Name, IsComplete = item.IsComplete }));
            }

            return Result<List<TodoItemDto>>.Success(todoItems);
        }
    }
}
