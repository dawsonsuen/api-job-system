using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace job_system_api.Model
{
    public interface IJobDataStore
    {
        //Job
        Task<IEnumerable<Job>> GetAllJobs();
        Job GetJob(int jobNumber);
        void AddJob(Job job);
        void UpdateJob(int jobNumber, Job job);
        bool Save();

        //User
        IEnumerable<Profile> GetAllProfiles();
        Profile GetProfile(int id);
        void AddProfile(Profile profile);
        void EditProfile(int id, Profile profile);
        void DeleteProfile(int id);
    }
}
