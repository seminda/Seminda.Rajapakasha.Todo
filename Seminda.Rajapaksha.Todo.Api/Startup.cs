using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Seminda.Rajapaksha.Todo.Api.Application.Command;
using Seminda.Rajapaksha.Todo.Api.Application.Query;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;
using Seminda.Rajapaksha.Todo.Api.Infrastructure.DataAccess;
using Seminda.Rajapaksha.Todo.Api.Infrastructure.Repository;

namespace Seminda.Rajapaksha.Todo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoItemContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));

            services.AddControllers();

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICreateTaskCommand, CreateTaskCommand>();
            services.AddScoped<IUpdateTaskCommand, UpdateTaskCommand>();
            services.AddScoped<IDeleteTaskCommand, DeleteTaskCommand>();
            services.AddScoped<IGetTaskQuery, GetTaskQuery>();
            services.AddScoped<IGetTaskListQuery, GetTaskListQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
