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
    public class DeleteTaskCommandTests
    {
        private readonly Fixture _fixture;
        private readonly ITaskRepository _taskRepositoryMock;
        private readonly IDeleteTaskCommand _deleteTaskCommand;

        public DeleteTaskCommandTests()
        {
            _fixture = new Fixture();
            _taskRepositoryMock = Substitute.For<ITaskRepository>();

            _deleteTaskCommand = new DeleteTaskCommand(_taskRepositoryMock);
        }

        [Fact]
        public async Task DeleteTaskCommand_Execute_Success()
        {
            var id = 3456;
           var todoTask = _fixture.Create<TodoItem>();
            todoTask.Id = id;

            _taskRepositoryMock.GetTask(Arg.Any<long>()).Returns(todoTask);
            _taskRepositoryMock.DeleteTask(Arg.Any<long>()).Returns(Task.FromResult(1));

            var result = await _deleteTaskCommand.Execute(id);

            result.IsSuccess().Should().BeTrue();
            result.Data.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteTaskCommand_Execute_Todo_NotFound()
        {
            var result = await _deleteTaskCommand.Execute(2345);

            result.IsSuccess().Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.NotFound);
            result.ErrorMessage.Should().Be(Constants.NotFoundErrorMessage);
        }
    }
}
