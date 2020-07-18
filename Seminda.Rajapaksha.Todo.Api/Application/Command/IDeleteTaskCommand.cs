using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Application.Model;

namespace Seminda.Rajapaksha.Todo.Api.Application.Command
{
    public interface IDeleteTaskCommand
    {
        Task<Result<bool>> Execute(long id);
    }
}
