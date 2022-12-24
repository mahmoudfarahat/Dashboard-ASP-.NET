using Assingment.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment.DAL.Contexts
{
    public  class MVCAppDbContext : IdentityDbContext<ApplicationUser,ApplicationRole, string>
    {
        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options) : base(options)
        {
        }

 
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
