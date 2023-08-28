using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Dto;
using Backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Uti
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles(){
            CreateMap<Employee,EmployeeDto>();
            CreateMap<EmployeeDepartment,EmployeeDepartmentDto>();
            CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.EmployeeDepartmentsDto, opt => opt.MapFrom(src => src.EmployeeDepartments));
        }
    }
}