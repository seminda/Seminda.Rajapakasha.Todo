using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;
using Seminda.Rajapaksha.Todo.Api.Infrastructure.DataAccess;

namespace Seminda.Rajapaksha.Todo.Api.Infrastructure.Repository
{
    public class TaskRepository: ITaskRepository
    {
        private readonly TodoItemContext _context;
        public TaskRepository(TodoItemContext context)
        {
            _context = context;
        }

        public async Task AddTask(TodoItem entity)
        {
            _context.TodoItems.Add(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateTask(TodoItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetTask(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(long id)
        {
            throw new NotImplementedException();
        }
    }
}
