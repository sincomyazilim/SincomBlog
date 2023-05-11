using SincomBlog.BusinessSin.Abstract;
using SincomBlog.DataAccessLayer.Abstract.UnitOfwork;
using SincomBlog.EntityLayer.Concrete;
using SincomBlog.EntitySin.Dtos.CategoryDto;
using SincomBlog.Sharedsin.Utilities.Result.Abstract;
using SincomBlog.Sharedsin.Utilities.Result.ComplexTypes;
using SincomBlog.Sharedsin.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.BusinessSin.Concrete
{
    public class CategoryManager : ICategoryService
    {//29-30

        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            
        }
        //------------------------------------------------------------------------------------
        public async Task<IResult> BAdd(CategoryAddDto categoryAddDto, string createdByName)
        {//30
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name =categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note=categoryAddDto.Note,
                IsActive=categoryAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName=createdByName,
                ModifiedDate=DateTime.Now,
                IsDeleted=false
            }).ContinueWith(x=>_unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,$"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir");
        }

       

        public async Task<IResult> BDelete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarıyla Silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı");
        }

        public async Task<IDataResult<IList<Category>>> BGetAllAysnc()
        {
            var categories=await _unitOfWork.Categories.GetAllAsync(null,x=>x.Articles);

            if (categories.Count > -1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Hiç Bir Kategori Bulunamadı", null);
        }

        public async Task<IDataResult<IList<Category>>> BGetAllByNonDeletedAysnc()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted,x=>x.Articles);
            if (categories.Count>-1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categories);   
            }
            return new DataResult<IList<Category>>(ResultStatus.Error,"Hiç Bir Kategori Bulunamadı", null);
        }

        public async Task<IDataResult<Category>> BGetAsync(int categoryId)
        {
            var category= await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId,x=>x.Articles);
            if (category!=null)
            {
                return new DataResult<Category>(ResultStatus.Success, category);
            }
            return new DataResult<Category>(ResultStatus.Error,"Böyle Bir Kategori Bulunamadı", null);
        }

       

        public async Task<IResult> BHardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);                
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} adlı kategori başarıyla veritabandan Silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı");
        }

        public async Task<IResult> BUpdate(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var categori = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryUpdateDto.Id);
            if (categori != null)
            {
                categori.Name= categoryUpdateDto.Name;
                categori.Description= categoryUpdateDto.Description;
                categori.Note= categoryUpdateDto.Note;
                categori.IsActive= categoryUpdateDto.IsActive;
                categori.IsDeleted= categoryUpdateDto.IsDeleted;
                categori.ModifiedByName=modifiedByName;
                categori.ModifiedDate=DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(categori);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı");
        }
    }
}
