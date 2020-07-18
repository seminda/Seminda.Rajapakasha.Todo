using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Seminda.Rajapaksha.Todo.Api.Application.Common;
using Seminda.Rajapaksha.Todo.Api.Application.Query;
using Seminda.Rajapaksha.Todo.Api.Domain.Model;
using Seminda.Rajapaksha.Todo.Api.Domain.Repository;
using Xunit;

namespace Seminda.Rajapaksha.Todo.Api.Tests
{
    public class GetTaskQueryTests
    {
        private readonly Fixture _fixture;
        private readonly ITaskRepository _taskRepositoryMock;
        private readonly IGetTaskQuery _getTaskQuery;

        public GetTaskQueryTests()
        {
            _fixture = new Fixture();
            _taskRepositoryMock = Substitute.For<ITaskRepository>();

            _getTaskQuery = new GetTaskQuery(_taskRepositoryMock);
        }

        [Fact]
        public async Task CreateTaskCommand_Execute_Success()
        {
            var todoTask = _fixture.Create<TodoItem>();

            _taskRepositoryMock.GetTask(Arg.Any<long>()).Returns(todoTask);


            var result = await _getTaskQuery.Execute(todoTask.Id);

            result.IsSuccess().Should().BeTrue();
            result.Data.Id.Should().Be(todoTask.Id);
        }

        [Fact]
        public async Task CreateTaskCommand_Execute_Todo_NotFound()
        {
            var id = 23894;

            var result = await _getTaskQuery.Execute(id);

            result.IsSuccess().Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.NotFound);
            result.ErrorMessage.Should().Be(Constants.NotFoundErrorMessage);
        }
    }
}
