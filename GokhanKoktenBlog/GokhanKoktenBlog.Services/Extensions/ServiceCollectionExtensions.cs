using GokhanKoktenBlog.Data.Abstract;
using GokhanKoktenBlog.Data.Concrete;
using GokhanKoktenBlog.Data.Concrete.EnityFremework.Contexts;
using GokhanKoktenBlog.Services.Abstract;
using GokhanKoktenBlog.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<GokhanKoktenBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
