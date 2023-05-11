using AutoMapper;
using SincomBlog.BusinessSin.Abstract;
using SincomBlog.DataAccessLayer.Abstract.UnitOfwork;
using SincomBlog.EntityLayer.Concrete;
using SincomBlog.EntitySin.Dtos.ArticleDto;
using SincomBlog.Sharedsin.Utilities.Result.Abstract;
using SincomBlog.Sharedsin.Utilities.Result.ComplexTypes;
using SincomBlog.Sharedsin.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.BusinessSin.Concrete//34-35-36
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //------------------------------------------------------------------------------------------
        public async Task<IResult> BAddAsync(ArticleAddDto articleAddDto, string createdByName)
        {//36
            var article=_mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,$"{articleAddDto.Title} başlıklı makale başarıyla eklenmiştir");
        }

        public async Task<IResult> BDeleteAsync(int articleId, string modifiedByName)
        {//36
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
               var article= await _unitOfWork.Articles.GetAsync(x=>x.Id==articleId);
                article.IsDeleted = true;
                article.ModifiedByName= modifiedByName;
                article.ModifiedDate=DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla silinmiştir");
            }
            return new Result(ResultStatus.Error, " Böyle bir makale bulunamadı");
        }

        public async Task<IDataResult<ArticleListDto>> BGetAllAysnc()
        {
            var article = await _unitOfWork.Articles.GetAllAsync(null, x => x.User, X500DistinguishedName => X500DistinguishedName.Category);
            if (article.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> BGetAllByCategoryAysnc(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(x => x.Id == categoryId);
            if (result)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(x => x.CategoryId == categoryId && !x.IsDeleted && x.IsActive, x => x.User, x => x.Category);

                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Böyle Bir Kategori bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> BGetAllByNonDeletedAndActiveAysnc()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.User, x => x.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleListDto>> BGetAllByNonDeletedAysnc()
        {
            var article = await _unitOfWork.Articles.GetAllAsync(x => !x.IsDeleted, x => x.User, x => x.Category);
            if (article.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    Articles = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, "Makaleler bulunamadı", null);
        }

        public async Task<IDataResult<ArticleDto>> BGetAsync(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId, x => x.User, x => x.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    Article = article,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, "Böyle bir makale bulunamadı", null);
        }

        public async Task<IResult> BHardDeleteAsync(int articleId)
        {//36
            var result = await _unitOfWork.Articles.AnyAsync(x => x.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(x => x.Id == articleId);
              
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{article.Title} başlıklı makale başarıyla veritabanından  silinmiştir");
            }
            return new Result(ResultStatus.Error, " Böyle bir makale bulunamadı");
        }

        public async Task<IResult> BUpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {//36
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
           await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleUpdateDto} başlıklı makale başarıyla güncellenmiştir");
        }
        //--------------------------------------------------------------------

    }
}
