using System;
using demoproject.Models;
using Microsoft.EntityFrameworkCore;

namespace demoproject.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions options) : base(options)
        {

        }

      public  DbSet<Employee> employee {get; set;}
        
    }
}