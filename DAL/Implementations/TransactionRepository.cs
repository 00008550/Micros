using DAL.DataFolder;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;
        private readonly IBalanceRepository _balanceRepository;

        public TransactionRepository(DataContext context, IBalanceRepository balanceRepository)
        {
            _context = context;
            _balanceRepository = balanceRepository;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction, string dateTime)
        {
          
            var result = await _balanceRepository.GetBalances();
            if(result.Count == 0)
            {
                Balance balance = new();
                List<Transaction> transactions = new();
                transactions.Add(transaction);
                if(dateTime != null)
                {
                    transaction.CreatedDate = DateTime.Parse(dateTime);
                }
                else
                {
                    transaction.CreatedDate = DateTime.UtcNow;
                }
                balance.ChangedDate = DateTime.UtcNow;
                balance.Amount = transaction.Amount;
                await _context.Balances.AddAsync(balance);
                await _context.Transactions.AddAsync(transaction);
                Log log = new() { Balance = balance, Time= DateTime.UtcNow, Transaction = transaction, Previous= 0, Added = transaction.Amount };
                await _context.Logs.AddAsync(log);
                await _context.SaveChangesAsync();

            }
            else
            {
                if(dateTime != null)
                {
                    transaction.CreatedDate = DateTime.Parse(dateTime);
                }
                else
                {
                    transaction.CreatedDate = DateTime.UtcNow;
                }
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                var lastBalance = await _balanceRepository.GetLastBalance();
                Log log = new() { Transaction = transaction, Balance = lastBalance, Time = DateTime.UtcNow, Previous = lastBalance.Amount, Added = transaction.Amount };
                lastBalance.ChangedDate = DateTime.UtcNow;
                lastBalance.Amount += transaction.Amount;
                _context.Balances.Update(lastBalance);
                await _context.Logs.AddAsync(log);
                await _context.SaveChangesAsync();
            }
            return transaction;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByCategory(string category)
        {
            return  await _context.Transactions.Where(x => x.Category.Name.ToLower() == category.ToLower()).ToListAsync();
        }

        public async Task<List<Transaction>> GetAllTransactionsByMonth(string month, string year)
        {
            var list = await _context.Transactions.ToListAsync();
            List<Transaction> result = new();
            for(int i = 0; i < list.Count; i++)
            {
                char[]? ya = year.ToCharArray();
                char[]? ma = month.ToCharArray();
                string? date = list[i].CreatedDate.ToString("MM/dd/yyyy");
                char[]? m = new char[] { date[0], date[1] };
                char[]? y = new char[] { date[6], date[7], date[8], date[9] };
                if (Enumerable.SequenceEqual(m,ma) && Enumerable.SequenceEqual(y,ya))
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

        public async Task<Transaction> GetByIdAsync(string id)
        {
            return await _context.Transactions.SingleOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public async Task<List<Transaction>> GetTransactionsByType(string type)
        {
            return await _context.Transactions.Where(x => x.Type.ToLower() == type.ToLower()).ToListAsync();
        }
    }
}
