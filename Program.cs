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
            var x = etool.Example2 ();
            //etool.ShowAll();
            Console.ReadKey();
        }
    }
}
