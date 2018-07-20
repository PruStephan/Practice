using System.Data.Entity;
using System.Security;
using System.Xml.Serialization;

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
