using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using job_system_api.Model;

namespace job_system_api.Controllers
{
    [ApiController]
    [Route("api/Profile")]
    public class ProfileController : Controller
    {
        private IJobDataStore _dbstore;
        public ProfileController(IJobDataStore dbstore)
        {
            _dbstore = dbstore;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbstore.GetAllProfiles());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            IActionResult result;
            var profile = _dbstore.GetProfile(Id);
            if (profile != null)
            {
                result = Ok(profile);
            }
            else
            {
                result = NotFound();
            }
            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Profile profile)
        {
            Profile newProfile = Profile.CreateProfileFromBody(profile);
            _dbstore.AddProfile(newProfile);
            return Ok();
        }

        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Profile profile)
        {
            _dbstore.EditProfile(Id, profile);
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _dbstore.DeleteProfile(Id);
        }
    }
}
