using Store.Entities;
using System.Collections.Generic;

namespace Store.Services.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();
    }
}
