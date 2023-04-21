using ApiNet6.Common.Dtos.Address;
using ApiNet6.Common.Dtos.Jobs;
using ApiNet6.Common.Dtos.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Dtos.Employee
{
    public record EmployeeDetails(int Id,string FirstName,string LastName,AddressGet Address,JobGet Job, List<TeamGet> teams);


   
}
