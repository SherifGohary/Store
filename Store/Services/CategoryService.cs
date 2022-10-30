using Store.DataAccess;
using Store.Entities;
using Store.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDpContext _dbContext;
        public CategoryService(AppDpContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }
    }
}
