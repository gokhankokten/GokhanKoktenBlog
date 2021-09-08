using GokhanKoktenBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Mvc.Areas.Admin.Models
{
    public class UserAddAjaxViewModel
    {
        public UserAddDto UserAddDto { get; set; }
        public string  UserAddPartial { get; set; }
        public UserDto UserDto { get; set; }
    }
}
