using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Dtos.Team
{
    public record TeamCreate(string Name,List<int> Employee);
    
}
