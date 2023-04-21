using ApiNet6.Common.Dtos.Address;
using ApiNet6.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet6.Crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private IAddressService AddressService { get; }

        public AddressController(IAddressService addressService)
        {
            AddressService = addressService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAddress(AddressCreate addressCreate)
        {
            var id = await AddressService.CreateAddressAsync(addressCreate);
            return Ok(id);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAddress(AddressUpdate addressUpdate)
        {
            await AddressService.UpdateAddressAsync(addressUpdate);
            return Ok();
        }
        [HttpPut]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAddress(AddressDelete addressUpdate)
        {
            await AddressService.DeleteAddressAsync(addressUpdate);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetAddress()
        {
            await AddressService.GetAddressesAsync();
            return Ok();

        }


    }
}
