using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Entities.Dtos
{
    public class UserListDto:DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
