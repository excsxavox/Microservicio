using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Interface;

namespace UserService.data
{
    public class DbContextI : DbContext
    {
        
    }

     public DbContextI(DbContextOptions<DbContextI> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<user> user { get; set; }
        
}
