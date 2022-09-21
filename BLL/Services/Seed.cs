using DAL.DataFolder;
using DAL.Entities;
using DAL.Implementations;

namespace BLL.Services
{
    public class Seed
    {
        public static async Task SeedCategories(CategoryRepository categoryRepository, DataContext context)
        {
            var categories = new List<Category>
            {
                new Category{Name = "salary"},
                new Category{Name = "loans"},
                new Category{Name = "anotherEarning"},
                new Category{Name = "groceries"},
                new Category{Name = "transport"},
                new Category{Name = "mobile"},
                new Category{Name = "entertainment"},
                new Category{Name = "anotherSpending"},
                new Category{Name = "internet"},
            };
            if (context.Categories.ToList() == null)
            {
                foreach (var category in categories)
                {
                    await categoryRepository.AddCategory(category);
                }
            }

            
        
    }
}
}
