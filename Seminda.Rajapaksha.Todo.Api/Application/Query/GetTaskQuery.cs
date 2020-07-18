using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Common;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;

namespace Seminda.Rajapaksha.Todo.Api.Application.Query
{
    public class GetTaskQuery : IGetTaskQuery
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskQuery(ITaskRepository repository)
        {
            _taskRepository = repository;
        }


        public async Task<Result<TodoItemDto>> Execute(long id)
        {
            var result = await _taskRepository.GetTask(id);

            if (result == null)
            {
                return Result<TodoItemDto>.Failed(ErrorCode.NotFound, Constants.NotFoundErrorMessage);
            }

            return Result<TodoItemDto>.Success(new TodoItemDto
            {
                Id = result.Id,
                Name = result.Name,
                IsComplete = result.IsComplete
            });
        }
    }
}
