using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace job_system_api.Model
{
    public class JobDataStore: IJobDataStore
    {        
        private JobDbContext _ctx;
        public JobDataStore(JobDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            var result = await _ctx.Jobs
                                .OrderBy(j => j.JobNumber).ToListAsync();

            return result;
        }

        public Job GetJob(int jobNumber)
        {
            return _ctx.Jobs.SingleOrDefault(x => x.JobNumber == jobNumber);
        }

        public void AddJob(Job job)
        {
            _ctx.Jobs.Add(job);
            Save();
        }

        public void UpdateJob(int jobNumber, Job job)
        {
            Job jobToUpdate = _ctx.Jobs.Find(jobNumber);
            jobToUpdate.Address = job.Address;
            jobToUpdate.Description = job.Description;
            jobToUpdate.JobType = job.JobType;
            jobToUpdate.JobStatus = job.JobStatus;
            jobToUpdate.StartDate = job.StartDate;
            jobToUpdate.CompletionDate = job.CompletionDate;
            jobToUpdate.HourEffort = job.HourEffort;
            jobToUpdate.LastModified = job.LastModified;
            Save();
        }

        public bool Save()
        {
            //True for success , False should throw exception
            return (_ctx.SaveChanges() >= 0);
        }

        //For User Controller
        public IEnumerable<Profile> GetAllProfiles()
        {
            var result = _ctx.Profiles

                           .OrderBy(u => u.Id).ToList();
            return result;
        }
        public Profile GetProfile(int Id)
        {
            return _ctx.Profiles.Find(Id);
        }
        public void AddProfile(Profile profile)
        {
            _ctx.Profiles.Add(profile);
            Save();
        }
        public void EditProfile(int Id, Profile profile)
        {
            Profile profileToEdit = _ctx.Profiles.Find(Id);
            profileToEdit.Name = profile.Name;
            profileToEdit.UserId = profile.UserId;
            profileToEdit.PhoneNumber = profile.PhoneNumber;
            profileToEdit.EmailAddress = profile.EmailAddress;

            Save();
        }
        public void DeleteProfile(int Id)
        {
            var profile = _ctx.Profiles.Find(Id);
            _ctx.Profiles.Remove(profile);
            Save();
        }

    }
}
