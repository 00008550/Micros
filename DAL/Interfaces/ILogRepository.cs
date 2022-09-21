using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllLogs();
        Task<List<Log>> GetLogsForMonth(string month, string year);
        Task<Log> GetByIdAsync(string id);

    }
}
