using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Product_Bidding_MVC.Models
{
    //Connects and  mapps the Identity related objects to the underlying databse tables.
    public class Product_Bidding_MVCIdentityContext : IdentityDbContext<IdentityUser>
    {
        public Product_Bidding_MVCIdentityContext(DbContextOptions<Product_Bidding_MVCIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
