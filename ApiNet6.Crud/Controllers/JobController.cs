using ApiNet6.Common.Dtos;
using ApiNet6.Common.Dtos.Jobs;
using ApiNet6.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet6.Crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private IJobService JobService { get; }

        public JobController(IJobService jobService)
        {
            JobService = jobService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob(JobCreate jobUpdate)
        {
            var id = await JobService.CraeteJobAsync(jobUpdate);
            return Ok(id);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateJob(JobUpdate jobUpdate)
        {
            await JobService.UpdateJobAsync(jobUpdate);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteJob(JobDelete jobUpdate)
        {
            await JobService.DeleteJobAsync(jobUpdate);
            return Ok();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var t = await JobService.GetJobAsync(id);
            return Ok(t);

        }


    }
}
