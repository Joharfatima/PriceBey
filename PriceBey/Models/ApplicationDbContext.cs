using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data.Entity;

namespace PriceBey.Models
{

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}

        public ApplicationDbContext()
        {
            Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<PriceClickHistory> PriceClickHistory { get; set; }
        public DbSet<ProductBooking> ProductBooking { get; set; }

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}
    }
}
