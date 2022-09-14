using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMS_Demo.Models;
using LMS_Demo.Models;

namespace LMS_Demo.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<Assesment> Assesments { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Teach> Teaches { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Facilitator> Facilitators { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SubmitAssignment> SubmitAssignments { get; set; }
        public virtual DbSet<AssesmentType> AssesmentTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
