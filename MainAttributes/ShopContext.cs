using System.Data.Entity;

namespace FreemiumGameShop.MainAttributes
{
    internal class ShopContext : DbContext
    {
        public ShopContext()
            : base("ShopDB")
        {
            Database.SetInitializer<ShopContext>(new DropCreateDatabaseAlways<ShopContext>());
        }

        public DbSet<DataAccess.Client> Clients
        {
            get;
            set;
        } 
    }
}
