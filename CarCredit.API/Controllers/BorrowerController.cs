using AutoMapper;
using CarCredit.API.Models.Borrower.DTO;
using CarCredit.API.Models.Borrower.Entity;
using CarCredit.API.Models.Car.DTO;
using CarCredit.API.Models.Car.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarCredit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BorrowerController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CeateBorrower(CreateBorrowerDto createBorrowerDto)
        {

            var borrower = _mapper.Map<Borrower>(createBorrowerDto);

            await _dbContext.Borrowers.AddAsync(borrower);
            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<ReadBorrowerDto>(borrower);

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBorrowers()
        {

            var borrowers = await _dbContext.Borrowers.Select(b => b).ToArrayAsync();

            var response = _mapper.Map<ICollection<ReadBorrowerDto>>(borrowers);

            return Ok(response);

        }
    }
}
