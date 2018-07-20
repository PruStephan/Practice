using System;
using System.Data.Entity;
using System.Linq;
using FreemiumGameShop.MainAttributes;

namespace FreemiumGameShop.Customer
{
    public class CustomerService
    {
        public void CreateCustomer(int clientId)
        {
            using (var sctx = new ShopContext())
            {
                var c = new DataAccess.Customer();
                sctx.Clients
                    .FirstOrDefault(cl => cl.Id == clientId)
                    ?.Customers
                    .Add(c);
                sctx.SaveChanges();
            }
        }

        public void ItemPurchase(int clientId, int customerId, string itemCode)
        {
            using (var sctx= new ShopContext())
            {
                var curClient = sctx.Clients.SingleOrDefault(c => c.Id == clientId);

                var curItem = sctx.Set<DataAccess.ShopItem>().SingleOrDefault(i => i.ItemCode == itemCode);

                var curCustomer = sctx.Set<DataAccess.Customer>().SingleOrDefault(cust => cust.Id == customerId);

                if (curItem == null)
                {
                    throw new Exception("No such Item");
                }

                if (curCustomer.Ammount < curItem.Price) 
                {
                    throw  new Exception("Not enough money");
                }

                var ii = new DataAccess.CustomerItem()
                {
                    ClientId = clientId,
                    Name = curItem.Name,
                    CustomerId = customerId,
                    ItemCode = curItem.ItemCode,
                    Price = curItem.Price
                };

                sctx.Set<DataAccess.CustomerItem>().Add(ii);
                sctx.SaveChanges();
            }
        }
    }
}
