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

            public CustomerDBContext() : base()
            {
               
            }

            public CustomerDBContext(DbContextOptions options): base(options)
            {

            }

     


    }
}
