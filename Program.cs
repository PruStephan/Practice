using System;
using System.Linq;
using FreemiumGameShop.Client;
using FreemiumGameShop.DataModels;
using FreemiumGameShop.Example;

namespace FreemiumGameShop
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var etool = new ExampleTool();
            etool.Example1();
            etool.ShowAll();
            ClientService.UpdateClient(1, new ClientModel(){Name = "New name"});
            etool.ShowAll();

            Console.WriteLine(ClientService.GetClient(1).Name);

            Console.ReadKey();
        }
    }
}
