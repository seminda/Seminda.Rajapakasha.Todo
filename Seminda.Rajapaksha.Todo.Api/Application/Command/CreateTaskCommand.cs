using System;
using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;

namespace Seminda.Rajapaksha.Todo.Api.Application.Command
{
    public class CreateTaskCommand : ICreateTaskCommand
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommand(ITaskRepository repository)
        {
            _taskRepository = repository;
        }

        public async Task<Result<CreateTodoItemResponseDto>> Execute(CreateTodoItemDto todoItem)
        {
            //TODO: Validation

            var id = DateTime.Now.ToFileTime();
            await _taskRepository.AddTask(new TodoItem
            {
                Id = id,
                Name = todoItem.Name,
                IsComplete = false

            });

            return Result<CreateTodoItemResponseDto>.Success(new CreateTodoItemResponseDto(id));
        }
    }
}
