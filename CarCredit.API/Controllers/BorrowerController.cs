using AutoMapper;
using CarCredit.API.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerController(IMapper mapper, IBorrowerRepository borrowerRepository)
        {
            _mapper = mapper;
            _borrowerRepository = borrowerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrower(CreateBorrowerDto createBorrowerDto)
        {

            var borrower = _mapper.Map<Borrower>(createBorrowerDto);

            await _borrowerRepository.Create(borrower);

            var response = _mapper.Map<ReadBorrowerDto>(borrower);

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBorrowers()
        {

            var borrowers = await _borrowerRepository.GetAll();

            var response = _mapper.Map<ICollection<ReadBorrowerDto>>(borrowers);

            return Ok(response);

        }
    }
}
