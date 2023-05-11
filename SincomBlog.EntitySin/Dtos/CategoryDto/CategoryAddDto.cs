﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.EntitySin.Dtos.CategoryDto
{//27
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} Boş Geçilmemelidir")]
        [MaxLength(70,ErrorMessage ="{0} {1} karekterden büyük olmamalıdır")]
        [MinLength(3,ErrorMessage ="{0} {1} karekterden az olmamalıdır")]
        public string Name { get; set; }


        [DisplayName("Kategori Açıklaması")]     
        [MaxLength(500, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karekterden az olmamalıdır")]
        public string Description { get; set; }


        [DisplayName("Kategori Özel Not Alanı")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(500, ErrorMessage = "{0} {1} karekterden büyük olmamalıdır")]
        [MinLength(3, ErrorMessage = "{0} {1} karekterden az olmamalıdır")]
        public string Note { get; set; }


        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir")]        
        public bool IsActive { get; set; }
    }
}
