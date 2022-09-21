using DAL.DataFolder;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }


        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public Task<Category> GetByNameAsync(string name)
        {
            return _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
