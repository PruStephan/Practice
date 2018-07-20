using System;
using System.Linq;
using FreemiumGameShop.MainAttributes;

namespace FreemiumGameShop.ShopItem
{
    internal class ShopItemService
    {
        public string GetCode(int clientId, string name)
        {
            using (var sctx = new MainAttributes.ShopContext())
            {
                var item = sctx.Set<DataAccess.ShopItem>().SingleOrDefault(i => i.Name == name && i.ClientId == clientId);
                if (item == null)
                {
                    throw new Exception("No such item in thse store: " + name);
                }

                return item.ItemCode;
            }
        }
    }
}