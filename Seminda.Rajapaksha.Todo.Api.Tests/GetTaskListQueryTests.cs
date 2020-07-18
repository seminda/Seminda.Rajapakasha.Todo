using System.Collections.Generic;
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
    public class GetTaskListQueryTests
    {
        private readonly Fixture _fixture;
        private readonly ITaskRepository _taskRepositoryMock;
        private readonly IGetTaskListQuery _getTaskListQuery;

        public GetTaskListQueryTests()
        {
            _fixture = new Fixture();
            _taskRepositoryMock = Substitute.For<ITaskRepository>();

            _getTaskListQuery = new GetTaskListQuery(_taskRepositoryMock);
        }

        [Fact]
        public async Task GetTaskListQuery_Execute_Success()
        {
            var todoTask = _fixture.Create<List<TodoItem>>();

            _taskRepositoryMock.GetAllTasks().Returns(todoTask);


            var result = await _getTaskListQuery.Execute();

            result.IsSuccess().Should().BeTrue();
            result.Data.Count.Should().Be(todoTask.Count);
        }

        [Fact]
        public async Task GetTaskListQuery_Execute_NoResults()
        {
            var id = 23894;

            var result = await _getTaskListQuery.Execute();

            result.IsSuccess().Should().BeTrue();
            result.Data.Count.Should().Be(0);
        }
    }
}
