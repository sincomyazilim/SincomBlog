using SincomBlog.EntityLayer.Concrete;
using SincomBlog.EntitySin.Dtos.ArticleDto;
using SincomBlog.EntitySin.Dtos.CategoryDto;
using SincomBlog.Sharedsin.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.BusinessSin.Abstract//31
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> BGetAsync(int articleId);
        Task<IDataResult<ArticleListDto>> BGetAllAysnc();
        Task<IDataResult<ArticleListDto>> BGetAllByNonDeletedAysnc();
        Task<IDataResult<ArticleListDto>> BGetAllByNonDeletedAndActiveAysnc();
        Task<IDataResult<ArticleListDto>> BGetAllByCategoryAysnc(int articleId);
        Task<IResult> BAddAsync(ArticleAddDto articleAddDto, string createdByName);
        Task<IResult> BUpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> BDeleteAsync(int articleId, string modifiedByName);
        Task<IResult> BHardDeleteAsync(int articleId);
    }
}
