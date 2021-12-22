using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace job_system_api.Model
{
    public class JobDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public JobDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Job
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Profile> Profiles { get; set; }

    }
}
