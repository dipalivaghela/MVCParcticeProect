using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    
        public class DBContextClass : DbContext
        {
            public DBContextClass(DbContextOptions<DBContextClass> options) : base(options)
            {
            }


            public DbSet<Tasks> Tasks { get; set; }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<UserProfile> Profiles { get; set; }
        }

    }

