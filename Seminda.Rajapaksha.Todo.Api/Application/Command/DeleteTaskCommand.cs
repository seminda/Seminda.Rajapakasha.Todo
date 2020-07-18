using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Common;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;

namespace Seminda.Rajapaksha.Todo.Api.Application.Command
{
    public class DeleteTaskCommand : IDeleteTaskCommand
    {

        private readonly ITaskRepository _taskRepository;
        public DeleteTaskCommand(ITaskRepository repository)
        {
            _taskRepository = repository;
        }
        
        public async Task<Result<bool>> Execute(long id)
        {
            var task = await _taskRepository.GetTask(id);

            if (task == null)
            {
                return Result<bool>.Failed(ErrorCode.NotFound, Constants.NotFoundErrorMessage);
            }

            await _taskRepository.DeleteTask(id);

            return Result<bool>.Success(true);
        }
    }
}
