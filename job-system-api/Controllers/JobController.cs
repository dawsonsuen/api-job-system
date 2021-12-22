using System;
using System.Threading.Tasks;
using job_system_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace job_system_api.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobController : Controller
    {
        private IJobDataStore _dbstore;

        public JobController(IJobDataStore dbstore)
        {
            _dbstore = dbstore;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbstore.GetAllJobs());
        }

        [HttpGet("{JobNumber}")]
        public IActionResult Get(int JobNumber)
        {
            IActionResult result;
            var job = _dbstore.GetJob(JobNumber);
            if (job != null)
            {
                result = Ok(job);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Job input)
        {
            Job newJob = Job.CreateJobFromBody(input);
            _dbstore.AddJob(newJob);
            _dbstore.Save();
            return Ok();
        }

        [HttpPut("{JobNumber}")]
        public void Put(int jobNumber,[FromBody] Job job)
        {
            _dbstore.UpdateJob(jobNumber,job);
        }
    }
}
