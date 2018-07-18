using System.Data.Entity;

namespace Freemium.Game.Shop.MainAttributes
{
    internal class ShopContext : DbContext
    {
        public ShopContext()
            : base("ShopDB")
        {
            Database.SetInitializer<ShopContext>(new DropCreateDatabaseAlways<ShopContext>());
        }

        public DbSet<Client.Client> Clients
        {
            get;
            set;
        } 
    }
}
