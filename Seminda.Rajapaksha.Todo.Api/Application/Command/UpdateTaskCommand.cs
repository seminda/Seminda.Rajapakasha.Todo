using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Common;
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
        
        public async Task<Result<CreateTodoItemResponseDto>> Execute(long id, UpdateTodoItemDto todoItem)
        {
            var task = await _taskRepository.GetTask(id);

            if (task == null)
            {
                return Result<CreateTodoItemResponseDto>.Failed(ErrorCode.NotFound, Constants.NotFoundErrorMessage);
            }

            task.Name = todoItem.Name;
            task.IsComplete = todoItem.IsComplete;

            await _taskRepository.UpdateTask(task);

            return Result<CreateTodoItemResponseDto>.Success(new CreateTodoItemResponseDto(id));
        }
    }
}
