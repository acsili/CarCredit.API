using AutoMapper;
using CarCredit.API.Interfaces;
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

        
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;


        public CarController(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository; 
        }

        [HttpPost]
        public async Task<IActionResult> CeateCar(CreateCarDto createCarDto)
        {

            var car = _mapper.Map<Car>(createCarDto);

            await _carRepository.Create(car);

            var response = _mapper.Map<ReadCarDto>(car);

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {

            var cars = await _carRepository.GetAll();

            var response = _mapper.Map<ICollection<ReadCarDto>>(cars);

            return Ok(response);

        }


    }

}
