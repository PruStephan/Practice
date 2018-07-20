using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FreemiumGameShop.MainAttributes;

namespace FreemiumGameShop.Client
{
    internal class ClientService
    {
        public void CreateClient(string name)
        {
            using (var sctx = new ShopContext())
            {
                var cl = new DataAccess.Client { Name = name };
                sctx.Clients.Add(cl);
                sctx.SaveChanges();
            }
        }

        public void AddItem(int clientId, string name, string code, double price)
        {
            using (var sctx = new ShopContext())
            {
                sctx.Set<DataAccess.ShopItem>()
                    .Add(new DataAccess.ShopItem() {ClientId = clientId, ItemCode = code, Name = name, Price = price});

                sctx.SaveChanges();
            }
        }

        public void AddCustomer(int clientId, double ammount)
        {
            using (var sctx = new ShopContext())
            {
                sctx.Set<DataAccess.Customer>()
                    .Add(new DataAccess.Customer() { ClientId = clientId, Ammount = ammount});
                sctx.SaveChanges();
            }
        }
    }
}