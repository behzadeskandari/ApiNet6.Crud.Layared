using ApiNet6.Business.services;
using ApiNet6.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Business
{
    public class DIConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoEntityMapperProfile));
            
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IJobService,JobService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITeamService, TeamService>();
        }
    }
}
