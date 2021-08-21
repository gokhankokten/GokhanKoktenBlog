using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createByName;
            category.ModifiedByName = createByName;
            var addedCategoryEntity = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto()
            {
                Category = addedCategoryEntity,
                Message = $"{ categoryAddDto.Name } başarıyla oluşturuldu",
                ResultStatus = ResultStatus.Success

            }, $"{categoryAddDto.Name} başarıyla oluşturuldu");

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
                return new Result(ResultStatus.Success, $"{category.Name} Adlı Kategory Silindi.");
            };
            return new Result(ResultStatus.Error, $"{category.Name} Adlı Bir Kategory Bulunamadı.");
        }


        public async Task<IDataResult<CategoryDto>> Get(int categoyId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoyId, c => c.Articles);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto()
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, new CategoryDto()
            {
                Category = null,
                Message = "Kategory Bulunamadı",
                ResultStatus = ResultStatus.Error

            }, "Kategory Bulunamadı");
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categorylist = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles);
            if (categorylist.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto()
                {
                    CategoryList = categorylist,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, new CategoryListDto
            {
                CategoryList = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir Kategori Bulunamadı"

            }, "Kategory Bulunamadı.");



        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto()
                {
                    ResultStatus = ResultStatus.Success,
                    CategoryList = categories
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "Hiç Bir Kategory bulunamadı");
        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted && c.IsActive, c => c.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto()
                {
                    ResultStatus = ResultStatus.Success,
                    CategoryList = categories
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, null, "Hiç Bir Kategory bulunamadı");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} Başarı ile silinmiştir");
            }
            return new Result(ResultStatus.Error, $"{category.Name} adlı Category Silinemedi");
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedNyName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedNyName;
            var addedCategoryEntity = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto()
            {
                Category = addedCategoryEntity,
                Message = $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellendi",
                ResultStatus = ResultStatus.Success


            }, $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellendi");

        }
    }
}
