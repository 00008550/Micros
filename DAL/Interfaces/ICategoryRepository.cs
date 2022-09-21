using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(string id);
        Task<Category> AddCategory(Category category);
        Task<Category> GetByNameAsync(string name);
        Task<List<Category>> GetAllAsync();

    }
}
