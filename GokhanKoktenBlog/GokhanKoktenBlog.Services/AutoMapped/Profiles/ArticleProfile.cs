using AutoMapper;
using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Services.AutoMapped.Profiles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.Now));
            CreateMap<ArticleUpdateDto, Article>().ForMember(dest=>dest.ModifiedDate,opt=>opt.MapFrom(x=>DateTime.Now));
        }
      
        
    }
}
