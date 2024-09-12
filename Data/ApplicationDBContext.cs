using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpApp.Data
{
    public class  ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions <ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

   
    

}