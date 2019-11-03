using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;

namespace Product_Bidding_MVC.Models
{
    //Connects and mapps the model layer objects to the underlying database.
    public class Product_Bidding_MVCContext : DbContext
    {
        public Product_Bidding_MVCContext (DbContextOptions<Product_Bidding_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Product_Bidding.BusinessLayer.Bid> Bid { get; set; }

        public DbSet<Product_Bidding.BusinessLayer.Buyer> Buyer { get; set; }

        public DbSet<Product_Bidding.BusinessLayer.Product> Product { get; set; }

        public DbSet<Product_Bidding.BusinessLayer.Seller> Seller { get; set; }
    }
}
