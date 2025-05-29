using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilots_GUI
{
    public class DataContext : DbContext
    {
        public DbSet<Pilot> Pilots { get; set; }        

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
                optionsBuilder.UseMySql("Server=localhost;Database=f1pilots;Uid=root;Pwd=;",
                    ServerVersion.AutoDetect("Server=localhost;Database=f1pilots;Uid=root;Pwd=;"));
            }
        }

        private static DataContext? context = null;

        public static DataContext GetContext()
        {
            if (context == null)
            {
                string? conStr = ConfigurationManager.ConnectionStrings["f1pilots"].ConnectionString;
                DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseMySql(
                    conStr, ServerVersion.AutoDetect(conStr));
                context = new(optionsBuilder.Options);
            }
            return context;
        }
    }
}
