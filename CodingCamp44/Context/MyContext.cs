using CodingCamp44.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.Context
{
    public class MyContext : DbContext
    {
        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
	    public DbSet<Education> Education { get; set; }
	    public DbSet<Job> Jobs { get; set; }
	    public DbSet<University> University { get; set; }
        public DbSet<Profiling> Profiling { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.Person).WithOne(b => b.Account).HasForeignKey<Account>(a => a.NIK);
	        modelBuilder.Entity<Education>().HasOne(x => x.University);
            modelBuilder.Entity<Profiling>().HasOne(x => x.Education);
            modelBuilder.Entity<Profiling>().HasOne(a => a.Person).WithOne(b => b.Profiling).HasForeignKey<Profiling>(a => a.NIK);
	        modelBuilder.Entity<Profiling>().HasOne(x => x.Job).WithMany(z => z.Profilings);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

