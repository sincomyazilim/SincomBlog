﻿using SincomBlog.EntityLayer.Concrete;
using SincomBlog.Sharedsin.Utilities.Result.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.EntitySin.Dtos.ArticleDto//32
{
    public class ArticleListDto:DtoGetBase
    {
        public  IList<Article> Articles { get; set; }
        
    }
}
