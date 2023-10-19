using AutoMapper;
using CarCredit.API.Models.Borrower.DTO;
using CarCredit.API.Models.Borrower.Entity;
using CarCredit.API.Models.Car.DTO;
using CarCredit.API.Models.Car.Entity;
using CarCredit.API.Models.Credit.DTO;
using CarCredit.API.Models.Credit.Entity;
using System.Numerics;

namespace CarCredit.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Car
            CreateMap<Car, ReadCarDto>();
            CreateMap<CreateCarDto, Car>();

            // Borrower
            CreateMap<Borrower, ReadBorrowerDto>();
            CreateMap<CreateBorrowerDto, Borrower>();

            // Credit
            CreateMap<Credit, ReadCreditDto>();
            CreateMap<CreateCreditDto, Credit>();

        }

    }
}
