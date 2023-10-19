using AutoMapper;
using CarCredit.API.Models.Car.DTO;
using CarCredit.API.Models.Car.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace CarCredit.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CeateCar(CreateCarDto createCarDto)
        {

            var car = _mapper.Map<Car>(createCarDto);

            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<ReadCarDto>(car);

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {

            var cars = await _dbContext.Cars.Select(c => c).ToArrayAsync();

            var response = _mapper.Map<ICollection<ReadCarDto>>(cars);

            return Ok(response);

        }


    }

}
