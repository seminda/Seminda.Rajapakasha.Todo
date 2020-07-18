using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateTask(TodoItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetTask(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            return todoItem;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTasks()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task DeleteTask(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
