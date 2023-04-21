using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Dtos.Employee
{
    public record EmployeeCreate(string FirstName, string LastName, int AddressId, int JobId);
    
}
