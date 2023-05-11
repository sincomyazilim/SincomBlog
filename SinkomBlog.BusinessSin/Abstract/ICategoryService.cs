using SincomBlog.EntityLayer.Concrete;
using SincomBlog.EntitySin.Dtos.CategoryDto;
using SincomBlog.Sharedsin.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.BusinessSin.Abstract
{//27
    public  interface ICategoryService
    {
        Task<IDataResult<Category>> BGetAsync(int categoryId);
        Task<IDataResult<IList<Category>>> BGetAllAysnc();
        Task<IDataResult<IList<Category>>> BGetAllByNonDeletedAysnc();
        Task<IResult> BAdd(CategoryAddDto categoryAddDto,string createdByName);
        Task<IResult> BUpdate(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> BDelete(int categoryId, string modifiedByName);
        Task<IResult> BHardDelete(int categoryId);
    }
}
