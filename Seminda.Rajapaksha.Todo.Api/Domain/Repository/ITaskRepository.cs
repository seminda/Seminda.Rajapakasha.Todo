using System.Collections.Generic;
using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;

namespace Seminda.Rajapaksha.Todo.Api.Domain.Repository
{
    public interface ITaskRepository
    {
        Task AddTask(TodoItem entity);
        Task UpdateTask(TodoItem entity);
        Task<TodoItem> GetTask(long id);
        Task<IEnumerable<TodoItem>> GetAllTasks();
        Task DeleteTask(long id);
    }
}
