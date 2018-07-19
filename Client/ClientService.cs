using System.Data.Entity;
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
                var cl = new Client { Name = name };
                sctx.Clients.Add(cl);
                sctx.SaveChanges();
            }
        }

        public void AddItem(int clientId, string name, double price)
        {
            using (var sctx = new ShopContext())
            {
                var curClient = sctx.Clients.Include(c => c.Items).SingleOrDefault(c => c.Id == clientId);
                curClient.Items.Add(new ShopItem.ShopItem { Name = name, Price = price, ClientId = curClient.Id });


                sctx.SaveChanges();
            }
        }

        public void AddCustomer(int clientId, double ammount)
        {
            using (var sctx = new ShopContext())
            {
                var clientList = sctx.Clients.Include(s => s.Customers).ToList();
                var curClient = clientList.SingleOrDefault(s => s.Id == clientId);
                curClient?.Customers.Add(new Customer.Customer { ClientId = curClient.Id, Ammount = ammount});

                sctx.SaveChanges();
            }
        }
    }
}