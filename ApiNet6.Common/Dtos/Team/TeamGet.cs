﻿using ApiNet6.Common.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Dtos.Team
{
    public record TeamGet(int Id,string Name,List<EmployeeList> Employees);
    
}
