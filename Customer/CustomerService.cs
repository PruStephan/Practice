using System;
using System.Data.Entity;
using System.Linq;
using FreemiumGameShop.DataAccess;
using FreemiumGameShop.DataModels;

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
                    Code = curItem.Code,
                    Price = curItem.Price
                };

                sctx.Set<DataAccess.CustomerItem>().Add(ii);
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
                    return curCust.ClientId + " :: " + curCust.Id + " :: " + curCust.Ammount;
                }

                return "failed to find customer: " + customerId;
            }
        }

        public static void CreateCustomer(int clientId, CustomerModel model)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                sctx.Set<DataAccess.Customer>()
                    .Add(new DataAccess.Customer() { ClientId = clientId, Ammount = model.Ammount, Nickname = model.Nickname});
                sctx.SaveChanges();
            }
        }

        public static void UpdateCustomer(int clientId, int customerId, CustomerModel model)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curCustomer = sctx.Set<DataAccess.Customer>()
                    .SingleOrDefault(cust => cust.ClientId == clientId && cust.Id == customerId);
                if (curCustomer== null)
                {
                    throw new Exception("There is no such Customer");
                }

                curCustomer.Ammount = model.Ammount;
                curCustomer.Nickname = model.Nickname;

                sctx.SaveChanges();
            }
        }

        public static void Deletecustomer(int clientId, int customerId)
        {
            using (var sctx = new ShopContext())
            {
                var curCustomer = sctx.Set<DataAccess.Customer>().SingleOrDefault(cust => cust.ClientId == clientId && cust.Id == customerId);
                sctx.Set<DataAccess.Customer>().Remove(curCustomer ?? throw new Exception("There is no such Customer"));
                sctx.SaveChanges();
            }
        }

        public static CustomerModel GetItem(int clientId, int customerId)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curCustomer= sctx.Set<DataAccess.Customer>()
                    .SingleOrDefault(cust => cust.ClientId == clientId && cust.Id == clientId);
                if (curCustomer== null)
                {
                    throw new Exception("There is no such item");
                }

                return new CustomerModel() { Ammount = curCustomer.Ammount, Nickname = curCustomer.Nickname};
            }
        }

    }
}
