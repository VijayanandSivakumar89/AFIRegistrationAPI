using AFIRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFIRegistrationAPI.AFIRegistration.DAL
{
    public class CustomerDBContext : DbContext
    {        
            public DbSet<Customer> Cust { get; set; }

            public string DbPath { get; }
            public CustomerDBContext() : base()
            {
                //var folder = Environment.SpecialFolder.LocalApplicationData;
                //var path = Environment.GetFolderPath(folder);
                DbPath = System.IO.Path.Join("D:\\Workplace\\Source\\Repos\\AFIRegistration\\AFIRegistrationAPI\\AFIRegistrationAPI\\APIRegistration.DAL\\Database", "AFI.db");
            }

            public CustomerDBContext(DbContextOptions options): base(options)
            {

            }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
           // => options.UseSqlite($"Data Source={DbPath}");



    }
}
