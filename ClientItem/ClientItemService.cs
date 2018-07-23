using System;
using System.Linq;

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
    }
}