using System.Web.Http;
using System.Web.Http.Routing;

namespace FreemiumGameShop.Client
{
    [RoutePrefix("client/{clientId}")]
    public class ClientController : ApiController
    {
        [Route("add/customers/ammount/{money}")]
        [HttpPost]
        public void AddCustomer(int clientId, double ammount)
        {
            ClientService.AddCustomer(clientId, ammount);
        }

        [Route("add/items/{name}/code/{code}/price/{price}")]
        [HttpPost]
        public void AddItem(int clientId, string name, string code, double price)
        {
            ClientService.AddItem(clientId, name, code, price);
        }

        [Route("get_customer/{customerId}")]
        [HttpGet]
        public string GetCustomer(int clientId, int customerId)
        {
            return ClientService.GetCustomer(clientId, customerId);
        }

        [Route("get_item/{code}")]
        [HttpGet]
        public string GetItem(int clientId, string code)
        {
            return ClientService.GetItem(clientId, code);
        }

/*        [Route("get_customer/{customerId}/new_ammount/{newAmmount}")]
        [HttpPut]
        public string ChangeCustomerAmmount(int clientId, int customerId, int newAmmount)
        {
            return ClientService.GetCustomer(clientId, customerId);
        }
*/
    }
}
