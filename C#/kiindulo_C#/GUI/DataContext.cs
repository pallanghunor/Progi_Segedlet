using Microsoft.EntityFrameworkCore;
using PCService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 
{
    public class DataContext : DbContext
    {
        public DbSet<> Orders { get; set; }
        // public DbSet<> Customers { get; set; }

        public DataContext()
        {

        }

        public DataContext(DbContextOptions _options) : base(_options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=!database!;Uid=root;Pwd=;",
                    ServerVersion.AutoDetect("Server=localhost;Database=!database!;Uid=root;Pwd=;"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<>().HasIndex(x => x.prop).IsUnique();
  //          modelBuilder.Entity<>().HasData(
    //            new { Id = 1, prop1 = "" },
     //      );
        }

        private static DataContext? context = null;

        public static DataContext GetContext()
        {
            if (context == null)
            {
                string? conStr = ConfigurationManager.ConnectionStrings["!database!"].ConnectionString;
                DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseMySql(
                    conStr, ServerVersion.AutoDetect(conStr));
                context = new(optionsBuilder.Options);
            }
            return context;
        }
    }
}
