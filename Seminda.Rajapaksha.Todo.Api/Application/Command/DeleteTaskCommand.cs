using System.Threading.Tasks;
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
        
        public Task<Result<bool>> Execute(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
