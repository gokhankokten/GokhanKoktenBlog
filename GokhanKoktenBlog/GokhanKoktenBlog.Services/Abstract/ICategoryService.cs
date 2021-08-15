using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Entities.Dtos;
using GokhanKoktenBlog.Shared.Utilities.Results.Abstract;
using GokhanKoktenBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoyId);
        Task<IDataResult<CategoryDto>> GetAll();
        Task<IDataResult<CategoryDto>> GetAllNonDeleted();
        Task<IDataResult<CategoryDto>> GetAllNonDeletedAndActive();
        Task<IResult> Add(CategoryAddDto categoryAddDto, string creatByName);
        Task<IResult> Delete(int categoryId,string modifiedByName);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedNyName);
        Task<IResult> HardDelete(int categoryId);


    }
}
