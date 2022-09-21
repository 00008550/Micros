using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        IBalanceRepository _balanceRepository;

        public BalanceController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }
        [HttpGet]
        public async Task<ActionResult<Balance>> GetBalance()
        {
            return Ok(await _balanceRepository.GetBalances());
        } 
    }
}
