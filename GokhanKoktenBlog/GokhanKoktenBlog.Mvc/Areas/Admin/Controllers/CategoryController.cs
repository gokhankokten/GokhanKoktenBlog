using GokhanKoktenBlog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GokhanKoktenBlog.Shared.Utilities.Results.ComplexTypes;

namespace GokhanKoktenBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _catetegoryService;

        public CategoryController(ICategoryService catetegoryService)
        {
            _catetegoryService = catetegoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _catetegoryService.GetAll();

            return View(result.Data);


        }
    }
}
