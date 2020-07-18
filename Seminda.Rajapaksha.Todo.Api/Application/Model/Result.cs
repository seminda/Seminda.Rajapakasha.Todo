using Seminda.Rajapaksha.Todo.Api.Application.Common;

namespace Seminda.Rajapaksha.Todo.Api.Application.Model
{
    public class Result<TData>
    {
        private Result(TData data)
        {
            Data = data;
        }

        private Result(ErrorCode errorCategory, string errorMsg)
        {
            ErrorMessage = errorMsg;
            ErrorCode = errorCategory;
        }
        
        private Result(ErrorCode errorCategory, string errorMsg, TData data)
        {
            ErrorMessage = errorMsg;
            ErrorCode = errorCategory;
            Data = data;
        }

        public ErrorCode? ErrorCode { get; }
        public string ErrorMessage { get; }
        public TData Data { get; }

        public bool IsSuccess()
        {
            return ErrorCode == null;
        }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>(data);
        }

        public static Result<TData> Failed(ErrorCode errorCategory, string errorMessage)
        {
            return new Result<TData>(errorCategory, errorMessage);
        }

        public static Result<TData> Failed(ErrorCode errorCategory, string errorMessage, TData data)
        {
            return new Result<TData>(errorCategory, errorMessage, data);
        }
    }
}
