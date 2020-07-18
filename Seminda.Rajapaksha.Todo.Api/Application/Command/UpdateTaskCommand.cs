using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;

namespace Seminda.Rajapaksha.Todo.Api.Application.Command
{
    public class UpdateTaskCommand : IUpdateTaskCommand
    {

        private readonly ITaskRepository _taskRepository;

        public UpdateTaskCommand(ITaskRepository repository)
        {
            _taskRepository = repository;
        }
        
        public Task<Result<CreateTodoItemResponseDto>> Execute(long id, UpdateTodoItemDto todoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
