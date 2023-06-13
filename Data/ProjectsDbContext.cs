using Microsoft.EntityFrameworkCore;
using Projects.Models;

namespace Projects.Data
{
    //My entity framework class
    public class ProjectsDbContext:DbContext
    {

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

    }
}
