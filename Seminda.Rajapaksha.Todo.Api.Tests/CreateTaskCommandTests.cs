using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Seminda.Rajapaksha.Todo.Api.Application.Command;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;
using Xunit;

namespace Seminda.Rajapaksha.Todo.Api.Tests
{
    public class CreateTaskCommandTests
    {
        private readonly Fixture _fixture;
        private readonly ITaskRepository _taskRepositoryMock;
        private readonly ICreateTaskCommand _createTaskCommand;

        public CreateTaskCommandTests()
        {
            _fixture = new Fixture();
            _taskRepositoryMock = Substitute.For<ITaskRepository>();

            _createTaskCommand = new CreateTaskCommand(_taskRepositoryMock);
        }

        [Fact]
        public async Task CreateTaskCommand_Execute_Success()
        {
            var todoTask = _fixture.Create<CreateTodoItemDto>();
            _taskRepositoryMock.AddTask(Arg.Any<TodoItem>()).Returns(Task.FromResult(1));

            var result = await _createTaskCommand.Execute(todoTask);

            result.IsSuccess().Should().BeTrue();
            result.Data.Id.Should().BeInRange(long.MinValue, long.MaxValue);
        }
    }
}
