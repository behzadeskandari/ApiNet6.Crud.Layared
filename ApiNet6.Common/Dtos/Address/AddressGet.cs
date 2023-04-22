using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Dtos.Address
{
    public record AddressGet(string Id,string Street,string Zip,string City,string Email,string? Phone);

}
