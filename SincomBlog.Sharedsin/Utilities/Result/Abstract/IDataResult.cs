using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.Sharedsin.Utilities.Result.Abstract//25
{
    public interface IDataResult<out T>:IResult//out anlamı T hem category hemde List<Category> olabılır
    {
        public T Data { get; }
        
    }
}
