using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Seminda.Rajapaksha.Todo.Api.Application.Command;
using Seminda.Rajapaksha.Todo.Api.Application.Common;
using Seminda.Rajapaksha.Todo.Api.Application.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;
using Xunit;

namespace Seminda.Rajapaksha.Todo.Api.Tests
{
    public class UpdateTaskCommandTests
    {
        private readonly Fixture _fixture;
        private readonly ITaskRepository _taskRepositoryMock;
        private readonly IUpdateTaskCommand _updateTaskCommand;

        public UpdateTaskCommandTests()
        {
            _fixture = new Fixture();
            _taskRepositoryMock = Substitute.For<ITaskRepository>();

            _updateTaskCommand = new UpdateTaskCommand(_taskRepositoryMock);
        }

        [Fact]
        public async Task UpdateTaskCommand_Execute_Success()
        {
            var id = 3456;
            var todoTaskDto = _fixture.Create<UpdateTodoItemDto>();
            var todoTask = _fixture.Create<TodoItem>();
            todoTask.Id = id;

            _taskRepositoryMock.GetTask(Arg.Any<long>()).Returns(todoTask);
            _taskRepositoryMock.UpdateTask(Arg.Any<TodoItem>()).Returns(Task.FromResult(1));

            var result = await _updateTaskCommand.Execute(2345, todoTaskDto);

            result.IsSuccess().Should().BeTrue();
        }

        [Fact]
        public async Task UpdateTaskCommand_Execute_Todo_NotFound()
        {
            var todoTask = _fixture.Create<UpdateTodoItemDto>();

            var result = await _updateTaskCommand.Execute(2345, todoTask);

            result.IsSuccess().Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.NotFound);
            result.ErrorMessage.Should().Be(Constants.NotFoundErrorMessage);
        }
    }
}
