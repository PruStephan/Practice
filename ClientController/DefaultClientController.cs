using System.Web.Http;
using System.Web.Http.Routing;
using FreemiumGameShop.Client;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.ClientController
{
    [RoutePrefix("clients")]
    public class DefaultClientController : ApiController
    {
        [Route("")]
        [HttpPost]
        public void CreateClient(ClientCreateModel clientCreateModel)
        {
           ClientService.CreateClient(clientCreateModel);
        }

        [Route("{clientId}/modification")]
        [HttpPut]
        public void UpdateClient(int clientId, ClientCreateModel clientCreateModel)
        {
            ClientService.UpdateClient(clientId, clientCreateModel);
        }

        [Route("{clientId}/deletion")]
        [HttpDelete]
        public void DeleteClient(int clientId)
        {
            ClientService.DeleteClient(clientId);
        }

        [Route("{clientId}/client")]
        [HttpGet]
        public ClientCreateModel GetClient(int clientId)
        {
            return ClientService.GetClient(clientId);
        }

    }
}
