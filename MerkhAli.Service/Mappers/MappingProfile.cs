using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;
using AutoMapper;
using MerkhAli.Domain.Entities.Foods;

namespace MerkhAli.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeForCreationDto, Employee>().ReverseMap();
        CreateMap<RoleForCreationsDto, Role>().ReverseMap();
        CreateMap<FoodForCreationDto, Food>().ReverseMap();
        CreateMap<FoodCategoryForCreationDto, FoodCategory>().ReverseMap();
    }
}