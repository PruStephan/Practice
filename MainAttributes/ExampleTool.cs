﻿using System;
using System.Data.Entity;
using System.Linq;

namespace FreemiumGameShop.MainAttributes
{
    internal class Utils
    {
        public void ShowAll()
        {
            using (ShopContext sctx = new ShopContext())
            {
                var clients = from cl in sctx.Clients.Include(i => i.Items).Include(c => c.Customers)
                              select cl;

                foreach (var client in clients)
                {
                    Console.WriteLine(client.Name + " :: " + client.Id + " ::Customer List:");
                    var customers = client.Customers.ToList();
                    foreach (var c in client.Customers)
                    {
                        Console.WriteLine(c.Id + " :: Ammount :: " + c.Ammount + "$$ :: Inventory:");

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