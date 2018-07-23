using System.Web.Http;

namespace FreemiumGameShop.ClientItem
{
    internal class ClientItemController : ApiController
    {
        [Route("api/{controller}")]
        public void Post(string name, double price)
        {
            ClientItemService shis = new ClientItemService();
          //  shis.CreateShopItem(name, price);
        }
    }
}
