﻿using GokhanKoktenBlog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GokhanKoktenBlog.Shared.Utilities.Results.ComplexTypes;
using GokhanKoktenBlog.Entities.Dtos;
using GokhanKoktenBlog.Mvc.Areas.Admin.Models;
using GokhanKoktenBlog.Shared.Utilities.Extensions;
using System.Text.Json;

namespace GokhanKoktenBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService catetegoryService)
        {
            _categoryService = catetegoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll();

            return View(result.Data);


        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto, "Gökhan KÖKTEN");
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    {

                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);


        }
        public async Task<JsonResult> GetAllCategories() 
        {
            var result = await _categoryService.GetAll();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve

            });
            return Json(categories);
        }
        [HttpPost]

        public async Task<JsonResult> Delete(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId, "Gökhan KÖKTEN");
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }
    }
}
