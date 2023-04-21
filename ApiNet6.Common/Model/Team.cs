using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Model
{
    public class Team : BaseEntity
    {
        public string Name { get; set; } = default!;

        public List<Employee> Employees { get; set; } = default!;
    }

}
