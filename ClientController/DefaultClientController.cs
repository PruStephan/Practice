using System.Web.Http;
using System.Web.Http.Routing;
using FreemiumGameShop.Client;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.ClientController
{
    [RoutePrefix("clients/{clientId}")]
    public class DefaultClientController : ApiController
    {
        [Route("creation/{clientModel}")]
        [HttpPost]
        public void CreateClient(ClientModel clientModel)
        {
            ClientService.CreateClient(clientModel);
        }

        [Route("modification/{clientModel}")]
        [HttpPut]
        public void UpdateClient(int clientId, ClientModel clientModel)
        {
            ClientService.UpdateClient(clientId, clientModel);
        }

        [Route("deletion")]
        [HttpDelete]
        public void DeleteClient(int clientId)
        {
            ClientService.DeleteClient(clientId);
        }

        [Route("returning")]
        [HttpGet]
        public ClientModel GetClient(int clientId)
        {
            return ClientService.GetClient(clientId);
        }

    }
}
