using GokhanKoktenBlog.Data.Abstract;
using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Entities.Dtos;
using GokhanKoktenBlog.Services.Abstract;
using GokhanKoktenBlog.Shared.Utilities.Results.Abstract;
using GokhanKoktenBlog.Shared.Utilities.Results.ComplexTypes;
using GokhanKoktenBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createByName)
        {
            await _unitOfWork.Categories.AddAsync(new Category()
            {
                CreatedByName = createByName,
                CreatedDate = DateTime.Now,
                Description = categoryAddDto.Description,
                IsActive = categoryAddDto.IsActive,
                Note = categoryAddDto.Note,
                Name = categoryAddDto.Name,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                ModifiedByName = createByName

            });
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} adlı kategory eklenmiştir.");

        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {

            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Kategory Silindi.");
            };
            return new Result(ResultStatus.Error, "Böyle Bir Kategory Bulunamadı.");
        }


        public async Task<IDataResult<Category>> Get(int categoyId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoyId, c => c.Articles);
            if (category != null)
            {
                return new DataResult<Category>(ResultStatus.Success, category);
            }
            return new DataResult<Category>(ResultStatus.Error, null, "Kategory Bulunamadı");
        }

        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categorylist = await _unitOfWork.Categories.GetAllAsync();
            return new DataResult<IList<Category>>(ResultStatus.Success, categorylist);
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            
            if (category!=null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Başarı ile silinmiştir");
            }
            return new Result(ResultStatus.Error, "Category Silinemedi");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedNyName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if (category!=null)
            {
                category.Name = categoryUpdateDto.Name;
                category.Description = categoryUpdateDto.Description;
                category.Note = categoryUpdateDto.Note;
                category.IsActive = categoryUpdateDto.IsActive;
                category.IsDeleted = categoryUpdateDto.IsDeleted;
                category.ModifiedByName = modifiedNyName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Güncelleme Başarı ile Yapıldı.");
            }
            return new Result(ResultStatus.Error, "Güncelleme Yapılamadı.");
        }
    }
}
