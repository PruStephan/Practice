using System;
using System.Linq;
using FreemiumGameShop.DataAccess;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.ClientItem
{
    internal class ClientItemService
    {
        public string GetCode(int clientId, string name)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var item = sctx.Set<DataAccess.ClientItem>().SingleOrDefault(i => i.Name == name && i.ClientId == clientId);
                if (item == null)
                {
                    throw new Exception("No such item in this store: " + name);
                }

                return item.Code;
            }
        }

        public static void CreateItem(int clientId, ClientItemModel clim)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                sctx.Set<DataAccess.ClientItem>()
                    .Add(new DataAccess.ClientItem() { ClientId = clientId, Code = clim.Code, Name = clim.Name, Price = clim.Price });
                sctx.SaveChanges();
            }
        }

        public static void UpdateItem(int clientId, string code, ClientItemModel model)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curItem = sctx.Set<DataAccess.ClientItem>()
                    .SingleOrDefault(item => item.ClientId == clientId && item.Code == code);
                if (curItem == null)
                {
                    throw new Exception("There is no such item");
                }

                curItem.Name = model.Name;
                curItem.Code = model.Code;
                curItem.Price = model.Price;

                sctx.SaveChanges();
            }
        }

        public static void DeleteItem(int clientId, string code)
        {
            using (var sctx = new ShopContext())
            {
                var curItem = sctx.Set<DataAccess.ClientItem>().SingleOrDefault(cli => cli.ClientId == clientId && cli.Code == code);
                sctx.Set<DataAccess.ClientItem>().Remove(curItem ?? throw new Exception("There is no such Item"));
                sctx.SaveChanges();
            }
        }

        public static ClientItemModel GetItem(int clientId, string code)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curItem = sctx.Set<DataAccess.ClientItem>()
                    .SingleOrDefault(item => item.ClientId == clientId && item.Code == code);
                if (curItem == null)
                {
                    throw new Exception("There is no such item");
                }
                
                return new ClientItemModel() { Code = curItem.Code, Name = curItem.Name, Price = curItem.Price};
            }
        }
    }
}