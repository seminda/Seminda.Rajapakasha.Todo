using Microsoft.EntityFrameworkCore;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;

namespace Seminda.Rajapaksha.Todo.Api.Infrastructure.DataAccess
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
