using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [MaxLength(100, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalı.")]
        [MinLength(5, ErrorMessage = "{0} Alanı {1} Karakterden Küçük Olmamalı.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [MinLength(20, ErrorMessage = "{0} Alanı {1} Karakterden Küçük Olmamalı.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [MaxLength(250, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalı.")]
        [MinLength(5, ErrorMessage = "{0} Alanı {1} Karakterden Küçük Olmamalı.")]
        public string Thumbnail { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [MaxLength(50, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalı.")]
        [MinLength(1, ErrorMessage = "{0} Alanı {1} Karakterden Küçük Olmamalı.")]
        public string SeoUther { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [MaxLength(150, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalı.")]
        [MinLength(1, ErrorMessage = "{0} Alanı {1} Karakterden Küçük Olmamalı.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [MaxLength(70, ErrorMessage = "{0} Alanı {1} Karakterden Büyük Olmamalı.")]
        [MinLength(1, ErrorMessage = "{0} Alanı {1} Karakterden Küçük Olmamalı.")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public int CategoryId { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public bool IsDeleted { get; set; }
    }
}
