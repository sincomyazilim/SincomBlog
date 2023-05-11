using AutoMapper;
using SincomBlog.EntityLayer.Concrete;
using SincomBlog.EntitySin.Dtos.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.BusinessSin.AutoMapper.Profiles//35
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(x => x.CreatedDate, x => x.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(x => x.ModifiedDate, x => x.MapFrom(x => DateTime.Now)); ;

        }
    }
}
