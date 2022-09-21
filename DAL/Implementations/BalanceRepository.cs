using DAL.DataFolder;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly DataContext _context;

        public BalanceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Balance>> GetAllBalancesByMonth(string month, string year)
        {
            var list = await _context.Balances.ToListAsync();
            List<Balance>? result = null;
            for (int i = 0; i < list.Count; i++)
            {
                char[]? ya = year.ToCharArray();
                char[]? ma = month.ToCharArray();
                string? date = list[i].ChangedDate.ToString("MM/dd/yyyy");
                char[]? m = new char[] { date[0], date[1] };
                char[]? y = new char[] { date[6], date[7], date[8], date[9] };
                if (m == ma && ya == y)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

        public async Task<List<Balance>> GetBalances()
        {
            return await _context.Balances.ToListAsync();
        }

        public async Task<Balance> GetByIdAsync(string id)
        {
            return await _context.Balances.SingleOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public async Task<Balance> GetLastBalance()
        {
            var list = await _context.Balances.ToListAsync();
            var result = list[^1];
            return result;
        }
    }
}
