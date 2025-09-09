using AutoMapper;
using EmployeeManagement.API.DTOs.Input;
using EmployeeManagement.Application.DTOs.Input;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.API.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeDTO>();

        }
    }
}