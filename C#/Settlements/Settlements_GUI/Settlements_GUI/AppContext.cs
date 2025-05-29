using Microsoft.EntityFrameworkCore;
using Settlements_GUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlements_GUI
{
    class AppContext : DbContext
    {
        public DbSet<Settlement> Settlement { get; set; }
        public DbSet<County> County { get; set; }


        public AppContext()
        {

        }

        public AppContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=settlements;Uid=root;Pwd=;", ServerVersion.AutoDetect("Server=localhost;Database=settlements;Uid=root;Pwd=;"));
        }

        private static AppContext? context = null;

        public static AppContext GetContext()
        {
            if (context == null)
            {
                var constStr = "Server=localhost;Database=settlements;Uid=root;Pwd=;";
                DbContextOptionsBuilder<AppContext> optionsBuilder = new DbContextOptionsBuilder<AppContext>().UseMySql(constStr, ServerVersion.AutoDetect(constStr));
                context = new AppContext(optionsBuilder.Options);
                context.Database.EnsureCreated();
            }
            return context;
        }

    }
}
