using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IBalanceRepository
    {
        Task<Balance> GetByIdAsync(string id);
        Task<Balance> GetLastBalance();
        Task<List<Balance>> GetBalances();
        Task<List<Balance>> GetAllBalancesByMonth(string month, string year);
    }
}
