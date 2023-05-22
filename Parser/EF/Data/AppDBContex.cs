using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 
using Parser.EF.Models;

namespace Parser.EF.Data
{
    public class AppDBContex : DbContext
    {
        
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<ConfigurationInfo> ConfigurationInfos { get; set; }
        public DbSet<PartGroup> PartGroups { get; set; }
        public DbSet<PartSubGroup> PartSubGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite(@"Data Source=parsedb.db");
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
