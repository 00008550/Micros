using BLL.Services;
using DAL.Dtos;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        readonly ITransactionRepository _transactionRepository;
        readonly ICategoryRepository _categoryRepository;
        CategoryService _categoryService;

        public TransactionsController(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository, CategoryService categoryService)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        [HttpGet("GetAllTransactions")]
        public async Task<ActionResult<List<TransactionDto>>> GetAll()
        {
            var result =await _transactionRepository.GetAllTransactions();
            if (result == null)
                return NotFound();
            List<TransactionDto> transactions = new();
            foreach(var transaction in result)
            {
                TransactionDto transactionDto = new()
                { Amount = transaction.Amount,
                Type = transaction.Type,
                Id = transaction.Id,
                Comment = transaction.Comment,
                CreatedDate = transaction.CreatedDate
                };
                transactions.Add(transactionDto);
            }
            return Ok(transactions);
        }
        [HttpGet("GetTransactionByCategory")]
        public async Task<ActionResult<List<TransactionDto>>> GetAllByCategory(string category)
        {
            List<TransactionDto> transactions = new();
            if (category != null)
            {
                var result = await _transactionRepository.GetAllTransactionsByCategory(category);
                if(result == null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var transaction in result)
                    {
                        TransactionDto transactionDto = new()
                        {
                            Amount = transaction.Amount,
                            Type = transaction.Type,
                            Id = transaction.Id,
                            Comment = transaction.Comment,
                            CreatedDate = transaction.CreatedDate
                        };
                        transactions.Add(transactionDto);
                    }
                    return Ok(transactions);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllByType")]
        public async Task<ActionResult<List<Transaction>>> GetAllByType(string type)
        {
            List<TransactionDto> transactions = new();
            if (type != null)
            {
                var result = await _transactionRepository.GetTransactionsByType(type);
                if(result== null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var transaction in result)
                    {
                       
                        TransactionDto transactionDto = new()
                        {
                            Amount = transaction.Amount,
                            Type = transaction.Type,
                            Id = transaction.Id,
                            Comment = transaction.Comment,
                            CreatedDate = transaction.CreatedDate,
                           
                        };
                        transactions.Add(transactionDto);
                    }
                    return Ok(transactions);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllByMonth")]
        public async Task<ActionResult<List<TransactionDto>>> GetAllByMonth(string month, string year)
        {
            List<TransactionDto> transactions = new();
            if (month != null)
            {
                var result = await _transactionRepository.GetAllTransactionsByMonth(month, year);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var transaction in result)
                    {
                        TransactionDto transactionDto = new()
                        {
                            Amount = transaction.Amount,
                            Type = transaction.Type,
                            Id = transaction.Id,
                            Comment = transaction.Comment,
                            CreatedDate = transaction.CreatedDate
                        };
                        transactions.Add(transactionDto);
                    }
                    return Ok(transactions);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddTransaction")]
        public async Task<ActionResult<Transaction>> PostTransaction(string type, string category, double amount, string comment, string? dateTime)
        {
            Transaction transaction = new();
            transaction.Amount = amount;
            transaction.Category = await _categoryRepository.GetByNameAsync(category);
            transaction.Comment = comment;
            transaction.Type = type;
            if (dateTime != null)
            {
                transaction.CreatedDate = DateTime.Parse(dateTime);
                
            }

            transaction.CreatedDate = DateTime.UtcNow;
            await _transactionRepository.AddTransaction(transaction, dateTime);
            return Ok(transaction);
        }
        [HttpPost("AddCategories")]
        public async Task<ActionResult<List<Category>>> AddCategories()
        {
            return await _categoryService.AddCategories();
        }
    }
}
