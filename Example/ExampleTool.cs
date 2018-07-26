using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FreemiumGameShop.Client;
using FreemiumGameShop.ClientItem;
using FreemiumGameShop.Customer;
using FreemiumGameShop.DataModels;
using Microsoft.Owin.Hosting;
using Flurl;
using Flurl.Http;

namespace FreemiumGameShop.Example
{
    internal class ExampleTool
    {
        public void Example1()
        {
            var cs = new Client.ClientService();
            var custs = new Customer.CustomerService();
            var sis = new ClientItem.ClientItemService();

            ClientService.CreateClient(new ClientCreateModel() { Name = "First client" });
            CustomerService.CreateCustomer(1, new CustomerCreateModel() { Ammount = 1000, Nickname = "Asdfg" });
            CustomerService.CreateCustomer(1, new CustomerCreateModel() { Ammount = 1000, Nickname = "Qwery" });

            ClientItemService.CreateItem(1, new ClientItemCreateModel() {Name = "Emperor's sword", Code = "asdgdi", Price = 500});
            ClientItemService.CreateItem(1, new ClientItemCreateModel() {Name = "The Book of Magnus", Code = "ygfoewrg", Price = 120});
            ClientItemService.CreateItem(1, new ClientItemCreateModel() {Name = "Sword of phoenix", Code = "sabgoiswbvg", Price = 400});

            string i1 = ClientItemService.GetItem(1, "asdgdi").Code;
            string i2 = ClientItemService.GetItem(1, "ygfoewrg").Code;
            string i3 = ClientItemService.GetItem(1, "sabgoiswbvg").Code;

            custs.ItemPurchase(1, 1, i1);
            custs.ItemPurchase(1, 1, i2);
            custs.ItemPurchase(1, 2, i3);
        }

        public async Task Example2()
        {
            string address = "http://localhost:9000/";

            using (WebApp.Start<WebAPI.Startup>(address))
            {
                var clientModel = new ClientCreateModel() {Name = "First Client"};
                var customerModel = new CustomerCreateModel(){Ammount = 1000, Nickname = "Alex"};
                var itemModel = new ClientItemCreateModel() {Code = "asd", Name = "Emperor's sword", Price = 500};

                var clientUrl = new Url(address + "clients");
                var resp = await clientUrl.PostJsonAsync(clientModel);

                
                Console.WriteLine(resp);

                //ClientService.CreateClient(clientModel);

                var customerUrl = new Url(address + "clients/customers").SetQueryParams(new { clientId = 1, model = customerModel });
                var resp3 = await customerUrl.PostAsync(new HttpMessageContent(new HttpRequestMessage()));

                Console.WriteLine(resp3);
                var itemUrl = new Url(address + "clients/items");
                var resp2 = await itemUrl.PostJsonAsync(new {clientId = 1, model = itemModel});

                Console.WriteLine(resp2);
            }
        }

        public void ShowAll()
        {
            using (DataAccess.ShopContext sctx = new DataAccess.ShopContext())
            {
                var clients = from cl in sctx.Clients.Include(i => i.Items).Include(c => c.Customers)
                              select cl;

                foreach (var client in clients)
                {
                    Console.WriteLine(client.Name + " :: " + client.Id + " :: Customer List:");
                    var customers = client.Customers.ToList();
                    foreach (var c in client.Customers)
                    {
                        Console.WriteLine(c.Id + " :: Amount :: " + c.Amount + "$$ :: Inventory:");

                        var inventoryList = sctx.Set<DataAccess.CustomerItem>().Where(i => i.CustomerId == c.Id).ToList();

                        foreach (var i in inventoryList)
                        {
                            Console.WriteLine("----------" + i.Name);
                        }
                    }
                }
            }
        }
    }
}