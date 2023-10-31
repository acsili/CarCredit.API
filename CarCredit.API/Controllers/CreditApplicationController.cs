using AutoMapper;
using CarCredit.API.Models.Borrower.Entity;
using CarCredit.API.Models.Car.Entity;
using CarCredit.API.Models.Credit.DTO;
using CarCredit.API.Models.Credit.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarCredit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CreditApplicationController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCreditApplications()
        {
            var credits = await _dbContext.Credits.Select(c => c).ToListAsync();
            var borrowers = await _dbContext.Borrowers.Select(b => b).ToListAsync();
            var cars = await _dbContext.Cars.Select(c => c).ToListAsync();

            var response = new List<CreditApplicationDto>();

            foreach (var credit in credits)
            {
                response.Add(new CreditApplicationDto()
                {
                    Id = credit.Id,
                    FullName = _dbContext.Borrowers.Find(credit.BorrowerId).FullName,
                    Model = _dbContext.Cars.Find(credit.CarId).Model,
                    Price = _dbContext.Cars.Find(credit.CarId).Price,
                    CreditTerm = credit.CreditTerm,
                    MonthlyPayment = credit.MonthlyPayment
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("credit/by-credit/{creditId:int}")]
        public async Task<IActionResult> GetCreditApplicationByCreditId(int creditId)
        {
            var credit = await _dbContext.Credits.FindAsync(creditId);
            var borrower = await _dbContext.Borrowers.FindAsync(credit.BorrowerId);
            var car = await _dbContext.Cars.FindAsync(credit.CarId);

            var response = new CreditApplicationDto()
            {
                Id = credit.Id,
                FullName = borrower.FullName,
                Model = car.Model,
                Price = car.Price,
                CreditTerm = credit.CreditTerm,
                MonthlyPayment = credit.MonthlyPayment
            };

            return Ok(response);
        }

        [HttpGet("credit/by-borrower/{borrowerId:int}")]
        public async Task<IActionResult> GetCreditApplicationsByBorrowerId(int borrowerId)
        {
            var borrower = await _dbContext.Borrowers.FindAsync(borrowerId);

            if (borrower == null)
            {
                return NotFound();
            }

            var credits = await _dbContext.Credits.Where(c => c.BorrowerId == borrowerId).ToListAsync();

            var response = new List<CreditApplicationDto>();

            foreach (var credit in credits)
            {
                response.Add(new CreditApplicationDto()
                {
                    Id = credit.Id,
                    FullName = borrower.FullName,
                    Model = _dbContext.Cars.Find(credit.CarId).Model,
                    Price = _dbContext.Cars.Find(credit.CarId).Price,
                    CreditTerm = credit.CreditTerm,
                    MonthlyPayment = credit.MonthlyPayment
                });
            }

            return Ok(response);

        }



    }
}
