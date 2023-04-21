using ApiNet6.Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser,IdentityRole, string>
    {
        //private readonly string connectionstring ;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            //connectionstring = "Server=.;Database=ApiNet6CrudCompany;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer(connectionstring);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().HasKey(e => e.Id);
            builder.Entity<Employee>().HasKey(e => e.Id);
            builder.Entity<Team>().HasKey(e => e.Id);
            builder.Entity<Job>().HasKey(e => e.Id);
            builder.Entity<Employee>().HasOne(e => e.Address);
            builder.Entity<Employee>().HasOne(e => e.job);

            builder.Entity<Team>().HasMany(e => e.Employees).WithMany(e => e.Teams);


            base.OnModelCreating(builder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Job> Jobs { get; set; }


    }
}
