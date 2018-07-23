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
                var curItem = sctx.Set<DataAccess.ClientItem>().SingleOrDefault(i => i.Code == itemCode);

                var curCustomer = sctx.Set<DataAccess.Customer>().SingleOrDefault(cust => cust.Id == customerId);

                if (curItem == null)
                {
                    throw new Exception("No such Item");
                }

                if (curCustomer == null)
                {
                    throw new Exception("Invaid customer");
                }

                if (curCustomer.Ammount < curItem.Price) 
                {
                    throw new Exception("Not enough money");
                }

                curCustomer.Ammount -= curItem.Price; 

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
