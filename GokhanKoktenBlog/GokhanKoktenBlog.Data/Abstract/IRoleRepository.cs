using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Data.Abstract
{
    public interface IRoleRepository: IEntityRepository<Role>
    {
    }
}
