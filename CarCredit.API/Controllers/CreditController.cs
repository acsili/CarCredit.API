using AutoMapper;
using CarCredit.API.Models.Credit.DTO;
using CarCredit.API.Models.Credit.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarCredit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {

        AppDbContext _dbContext;
        IMapper _mapper;

        public CreditController(AppDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCredit(CreateCreditDto createCreditDto)
        {
            var credit = _mapper.Map<Credit>(createCreditDto);

            await _dbContext.Credits.AddAsync(credit);
            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<ReadCreditDto>(credit);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCredits()
        {

            var credits = await _dbContext.Credits.Select(c => c).ToArrayAsync();

            var response = _mapper.Map<ICollection<ReadCreditDto>>(credits);

            return Ok(response);

        }
    }
}
