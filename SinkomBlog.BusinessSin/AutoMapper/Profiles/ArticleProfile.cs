using AutoMapper;
using SincomBlog.EntityLayer.Concrete;
using SincomBlog.EntitySin.Dtos.ArticleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.BusinessSin.AutoMapper.Profiles//36 bu katmanda automapper kurduk bunısess katmanına kuruluyor mapleme yapma ıcın
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(x=>x.CreatedDate,x=>x.MapFrom(x=>DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>().ForMember(x => x.ModifiedDate, x => x.MapFrom(x => DateTime.Now)); ;
        }
    }
}
