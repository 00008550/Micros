using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(string id);
        Task<Transaction> AddTransaction(Transaction transaction, string dateTime);
        Task<List<Transaction>> GetAllTransactionsByCategory(string category);
        Task<List<Transaction>> GetAllTransactions();
        Task<List<Transaction>> GetAllTransactionsByMonth(string month, string year);
        Task<List<Transaction>> GetTransactionsByType (string type);

    }
}
