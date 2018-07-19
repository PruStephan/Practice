using System;
using System.Data.Entity;
using System.Linq;
using FreemiumGameShop.InvetntoryItem;
using FreemiumGameShop.MainAttributes;

namespace FreemiumGameShop.Customer
{
    public class CustomerService
    {
        public void CreateCustomer(int clientId)
        {
            using (var sctx = new ShopContext())
            {
                var c = new Customer();
                sctx.Clients
                    .FirstOrDefault(cl => cl.Id == clientId)
                    ?.Customers
                    .Add(c);
                sctx.SaveChanges();
            }
        }

        public void ItemPurchase(int clientId, int customerId, string itemName)
        {
            using (var sctx= new ShopContext())
            {
                var clientList = sctx.Clients.Include(cl => cl.Items).Include(cl => cl.Customers).ToList();

                var curClient = clientList.SingleOrDefault(cl => cl.Id == clientId);

                var curCustomer = curClient.Customers.SingleOrDefault(c => c.Id == customerId);

                var curItem = curClient.Items.SingleOrDefault(i => i.Name == itemName);

                if (curItem == null)
                {
                    throw new Exception("There is no such item: " + itemName);
                }

                if (curCustomer.Ammount < curItem.Price)
                {
                    throw new Exception("Not enough money");
                }

                CustomerItem ii = new CustomerItem
                {
                    Name = curItem.Name,
                    Price = curItem.Price,
                    ClientId = clientId,
                    CustomerId = customerId
                };
                curCustomer.Ammount -= curItem.Price;
                var inventoryList = sctx.Set<CustomerItem>();
                inventoryList.Add(ii);

                sctx.SaveChanges();
            }
        }
    }
}
