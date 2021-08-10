﻿using GokhanKoktenBlog.Data.Abstract;
using GokhanKoktenBlog.Entities.Concrete;
using GokhanKoktenBlog.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GokhanKoktenBlog.Data.Concrete.EnityFremework.Repositories
{
    public class EfArticleRepository:EfEntityRepositoryBase<Article>,IArticleRepository
    {
        public EfArticleRepository(DbContext context) : base(context)
        { 
        }
    }
}
