using ApiNet6.Common.Dtos.Employee;
using ApiNet6.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet6.Crud.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService EmployeeService { get; }

        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEmployee(EmployeeCreate addressCreate)
        {
            var id = await EmployeeService.CreateEmployeeAsync(addressCreate);
            return Ok(id);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdate addressUpdate)
        {
            await EmployeeService.UpdateEmployeeAsync(addressUpdate);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteEmployee(EmployeeDelete addressUpdate)
        {
            await EmployeeService.DeleteEmployeeAsync(addressUpdate);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var t = await EmployeeService.GetEmployeeAsync(id);
            return Ok(t);

        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetEmployees([FromQuery]EmployeeFilter employeeFilter)
        {
            var t = await EmployeeService.GetEmployeesAsync(employeeFilter);
            return Ok(t);

        }
    }

}
