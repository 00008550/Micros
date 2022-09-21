using DAL.Dtos;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        readonly ILogRepository _logRepository;

        public LogsController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<LogDto>>> GetAll()
        {
            var logs = await _logRepository.GetAllLogs();
            if (logs == null)
                return NotFound();
            List<LogDto> logDtos = new();
            foreach(var logDto in logs)
            {
                LogDto log = new() { AddedAmount = logDto.Added.ToString(), Id = logDto.Id, CreatedDate = logDto.Time, PreviousBalance = logDto.Previous.ToString() };
                logDtos.Add(log);
            }
            return Ok(logDtos);
        }
        [HttpGet("GetByMonth")]
        public async Task<ActionResult<List<Log>>> GetLogsByMonth(string month, string year)
        {
            var logs = await _logRepository.GetLogsForMonth(month, year);

            if (logs == null)
                return NotFound();
            List<LogDto> logDtos = new();
            foreach (var logDto in logs)
            {
                LogDto log = new() { AddedAmount = logDto.Added.ToString(), Id = logDto.Id, CreatedDate = logDto.Time, PreviousBalance = logDto.Previous.ToString() };
                logDtos.Add(log);
            }
            return Ok(logDtos);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<LogDto>> GetById(string id)
        {
            var result = await _logRepository.GetByIdAsync(id);
            LogDto logDto = new() { AddedAmount = result.Added.ToString(), CreatedDate = result.Time, PreviousBalance = result.Previous.ToString(), Id= result.Id };
            return Ok(logDto);
        }
    }
}
