using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace job_system_api.Model
{
    public class Job
    {
        public static Job CreateJobFromBody(Job jobInputModel)
        {
            Job newJob = new Job();
            newJob.Address = jobInputModel.Address;
            newJob.Description = jobInputModel.Description;
            newJob.JobType = jobInputModel.JobType;
            newJob.JobStatus = jobInputModel.JobStatus;
            newJob.StartDate = jobInputModel.StartDate;
            newJob.CompletionDate = jobInputModel.CompletionDate;
            newJob.HourEffort = jobInputModel.HourEffort;
            newJob.LastModified = jobInputModel.LastModified;

            return newJob;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobNumber { get; set; }

        public string Address { get; set; }
        public string Description { get; set; }
        public string JobType { get; set; }
        public string JobStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public Decimal HourEffort { get; set; }
        public DateTime LastModified { get; set; }
        public Job()
        {
        }
    }
}
