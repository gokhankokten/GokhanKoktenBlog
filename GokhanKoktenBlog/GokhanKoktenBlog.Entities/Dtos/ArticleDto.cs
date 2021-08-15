using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Shared.Data.Abstract;
using GokhanKoktenBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Entities.Dtos
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
        
    }
}
