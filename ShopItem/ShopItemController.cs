using System.Web.Http;

namespace FreemiumGameShop.ShopItem
{
    internal class ShopItemController : ApiController
    {
        [Route("api/{controller}")]
        public void Post(string name, double price)
        {
            ShopItemService shis = new ShopItemService();
          //  shis.CreateShopItem(name, price);
        }
    }
}
