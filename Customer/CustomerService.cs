using System;
using System.Data.Entity;
using System.Linq;

namespace FreemiumGameShop.Customer
{
    public class CustomerService
    {
        public void ItemPurchase(int clientId, int customerId, string itemCode)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curClient = sctx.Clients.SingleOrDefault(c => c.Id == clientId);

                var curItem = sctx.Set<DataAccess.ClientItem>().SingleOrDefault(i => i.Code == itemCode);

                var curCustomer = sctx.Set<DataAccess.Customer>().SingleOrDefault(cust => cust.Id == customerId);

                if (curItem == null)
                {
                    throw new Exception("No such Item");
                }

                if (curCustomer.Ammount < curItem.Price) 
                {
                    throw new Exception("Not enough money");
                }

                var ii = new DataAccess.CustomerItem()
                {
                    Name = curItem.Name,
                    CustomerId = customerId,
                    ItemCode = curItem.Code,
                    Price = curItem.Price
                };

                sctx.Set<DataAccess.CustomerItem>().Add(ii);
                sctx.SaveChanges();
            }
        }
    }
}
