namespace Seminda.Rajapaksha.Todo.Api.Application.Model
{
    public class CreateTodoItemResponseDto
    {
        public CreateTodoItemResponseDto(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
