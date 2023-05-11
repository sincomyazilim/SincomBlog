using SincomBlog.Sharedsin.Utilities.Result.ComplexTypes;

namespace SincomBlog.Sharedsin.Utilities.Result.Abstract//23
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;  }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
