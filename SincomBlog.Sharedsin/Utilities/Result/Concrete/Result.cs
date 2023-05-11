using SincomBlog.Sharedsin.Utilities.Result.Abstract;
using SincomBlog.Sharedsin.Utilities.Result.ComplexTypes;

namespace SincomBlog.Sharedsin.Utilities.Result.Concrete//24
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message, Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
