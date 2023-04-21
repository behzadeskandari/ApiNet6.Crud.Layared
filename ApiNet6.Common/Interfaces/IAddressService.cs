using ApiNet6.Common.Dtos.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Common.Interfaces
{
    public interface IAddressService
    {
        Task<int> CreateAddressAsync(AddressCreate addressCreate);

        Task UpdateAddressAsync(AddressUpdate addressUpdate);

        Task DeleteAddressAsync(AddressDelete addressDelete);

        Task<List<AddressGet>> GetAddressesAsync();

    }
}
