using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FreemiumGameShop.Client
{
    internal class ClientService
    {
        public void CreateClient(string name)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var cl = new DataAccess.Client { Name = name };
                sctx.Clients.Add(cl);
                sctx.SaveChanges();
            }
        }

        public static void AddItem(int clientId, string name, string code, double price)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                sctx.Set<DataAccess.ClientItem>()
                    .Add(new DataAccess.ClientItem() { ClientId = clientId, Code = code, Name = name, Price = price });
                sctx.SaveChanges();
            }
        }

        public static void AddCustomer(int clientId, double ammount)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                sctx.Set<DataAccess.Customer>()
                    .Add(new DataAccess.Customer() { ClientId = clientId, Ammount = ammount });
                sctx.SaveChanges();
            }
        }

        public static string GetCustomer(int clientId, int customerId)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curCust = sctx.Set<DataAccess.Customer>()
                    .SingleOrDefault(cust => cust.ClientId == clientId && cust.Id == customerId);
                if (curCust != null)
                {
                    return curCust.ClientId + " :: " + curCust.Id + " :: " + curCust.Ammount + " :: " +
                           curCust.Inventory.Count;
                }

                return "failed to find customer: " + customerId;
            }
        }
    }
}