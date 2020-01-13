using DataAccess.Properties;
using ProductMicroservice.Core.Model;
using System.Data.Entity;


namespace DataAccess.Contexts
{
    public class OnlineStoreContexts : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Carts> Carts { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        public OnlineStoreContexts() : base(Settings.Default.DefaultConnectionString)
        {

        }
    }
}
