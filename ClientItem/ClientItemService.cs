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

        public static void CreateItem(int clientId, ClientItemCreateModel clim)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                sctx.Set<DataAccess.ClientItem>()
                    .Add(new DataAccess.ClientItem() { ClientId = clientId, Code = clim.Code, Name = clim.Name, Price = clim.Price });
                sctx.SaveChanges();
            }
        }

        public static void UpdateItem(int clientId, string code, ClientItemCreateModel createModel)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curItem = sctx.Set<DataAccess.ClientItem>()
                    .SingleOrDefault(item => item.ClientId == clientId && item.Code == code);
                if (curItem == null)
                {
                    throw new Exception("There is no such item");
                }

                curItem.Name = createModel.Name;
                curItem.Code = createModel.Code;
                curItem.Price = createModel.Price;

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

        public static ClientItemCreateModel GetItem(int clientId, string code)
        {
            using (var sctx = new DataAccess.ShopContext())
            {
                var curItem = sctx.Set<DataAccess.ClientItem>()
                    .SingleOrDefault(item => item.ClientId == clientId && item.Code == code);
                if (curItem == null)
                {
                    throw new Exception("There is no such item");
                }
                
                return new ClientItemCreateModel() { Code = curItem.Code, Name = curItem.Name, Price = curItem.Price};
            }
        }
    }
}