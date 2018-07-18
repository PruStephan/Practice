using System.Web.Http;

namespace Freemium.Game.Shop.ShopItem
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
