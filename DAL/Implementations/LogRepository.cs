using DAL.DataFolder;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class LogRepository : ILogRepository
    {
        private readonly DataContext _context;

        public LogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> GetAllLogs()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Log> GetByIdAsync(string id)
        {
            return await _context.Logs.SingleOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public async Task<List<Log>> GetLogsForMonth(string month, string year)
        {
            var list = await _context.Logs.ToListAsync();
            List<Log> result = null;
            for (int i = 0; i < list.Count; i++)
            {
                char[]? ya = year.ToCharArray();
                char[]? ma = month.ToCharArray();
                string? date = list[i].Transaction.CreatedDate.ToString("MM/dd/yyyy");
                char[]? m = new char[] { date[0], date[1] };
                char[]? y = new char[] { date[6], date[7], date[8], date[9] };
                if (m == ma && ya == y)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }
    }
}
