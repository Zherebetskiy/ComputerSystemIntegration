using AutoMapper;
using ComputerSystemIntegration.Domain.Models;

namespace ComputerSystemIntegration.DataAccess.DAL
{
     public class VacancyProfile : Profile
    {
        public VacancyProfile()
        {
            CreateMap<VacancyEntity, Vacancy>();
            CreateMap<Vacancy, VacancyEntity>();
        }
    }
}
