using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> AddCategories()
        {
            var categories = new List<Category>
            {
                new Category{Name = "Salary"},
                new Category{Name = "Loans"},
                new Category{Name = "AnotherEarning"},
                new Category{Name = "Groceries"},
                new Category{Name = "Transport"},
                new Category{Name = "Mobile"},
                new Category{Name = "Entertainment"},
                new Category{Name = "AnotherSpending"},
                new Category{Name = "Internet"},
            };
            var result = await _categoryRepository.GetAllAsync();
            if (result.Count == 0)
            {
                foreach (var category in categories)
                {
                    await _categoryRepository.AddCategory(category);
                }
            }
            return categories;
        }
       
    }
}
