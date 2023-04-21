using ApiNet6.Common.Dtos;
using ApiNet6.Common.Dtos.Address;
using ApiNet6.Common.Interfaces;
using ApiNet6.Common.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Business.services
{
    public class AddressService : IAddressService
    {
        public IMapper Mapper { get; }
        public IGenericRepository<Address> AddressRepository { get; }

        public AddressService(IMapper mapper,IGenericRepository<Address> addressRepository)
        {
            Mapper = mapper;
            AddressRepository = addressRepository;
        }

        public async Task<int> CreateAddressAsync(AddressCreate addressCreate)
        {
            var entity = Mapper.Map<Address>(addressCreate);
            await AddressRepository.InsertAsync(entity);
            await AddressRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAddressAsync(AddressDelete addressDelete)
        {
            var entity = await AddressRepository.GetByIdAsync(addressDelete.Id);
            AddressRepository.Delete(entity);
            await AddressRepository.SaveChangesAsync();
        }

        public async Task<List<AddressGet>> GetAddressesAsync()
        {
            var entity = await AddressRepository.GetAysnc(null, null);
            return Mapper.Map<List<AddressGet>>(entity);

        }

        public async Task UpdateAddressAsync(AddressUpdate addressUpdate)
        {
            var entity = Mapper.Map<Address>(addressUpdate);
            AddressRepository.Update(entity);
            await AddressRepository.SaveChangesAsync();


        }
    }
}
