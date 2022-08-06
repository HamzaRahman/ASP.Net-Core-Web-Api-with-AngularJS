using ASP_AngularJS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_AngularJS.Repo
{
    public class PeopleContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PeopleDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Person> People { get; set; }
    }
}
