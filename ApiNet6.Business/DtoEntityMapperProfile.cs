using ApiNet6.Common.Dtos;
using ApiNet6.Common.Dtos.Address;
using ApiNet6.Common.Dtos.Employee;
using ApiNet6.Common.Dtos.Jobs;
using ApiNet6.Common.Dtos.Team;
using ApiNet6.Common.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Business
{
    public class DtoEntityMapperProfile : Profile
    {
        public DtoEntityMapperProfile()
        {
            CreateMap<AddressCreate, Address>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<AddressDelete, Address>();
            CreateMap<AddressUpdate, Address>();
            CreateMap<Address, AddressGet>();

            CreateMap<JobCreate, Job>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<JobUpdate, Job>();
            CreateMap<Job, JobGet>();


            CreateMap<EmployeeCreate, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Teams, opt => opt.Ignore())
                .ForMember(dest => dest.job, opt => opt.Ignore());

            CreateMap<EmployeeUpdate, Employee>();
            CreateMap<Employee, EmployeeDetails>().ForMember(dest=> dest.Id , opt => opt.Ignore())
                //.ForMember(dest => dest.Teams, opt => opt.Ignore())
                .ForMember(dest => dest.Job, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore());
            //CreateMap<Employee, EmployeeGet>();

            CreateMap<Employee, EmployeeList>();

            CreateMap<TeamCreate, Team>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.Employees, opt => opt.Ignore());
                
            CreateMap<TeamUpdate,Team>().ForMember(dest => dest.Employees, opt => opt.Ignore());

            CreateMap<Team, TeamGet>();
        }

    }
}
