using System.Web.Http;
using System.Web.Http.Routing;

namespace FreemiumGameShop.Client
{
    public class ClientController : ApiController
    {
        [Route("client/{clientId}/add/customers/ammount/{money}")]
        [HttpPost]
        public void CreateCustomer(int clientId, double ammount)
        {
            ClientService.AddCustomer(clientId, ammount);
        }

        [Route("client/{cientId}/add/items/{name}/code/{code}/price/{price}")]
        public void CreateItem(int clientId, string name, string code, double price)
        {
            ClientService.AddItem(clientId, name, code, price);
        }

        [Route("client/{clientId}/get_customer/{customerId}")]
        [HttpGet]
        public string GetCustomer(int clientId, int customerId)
        {
            return ClientService.GetCustomer(clientId, customerId);
        }
    }
}
