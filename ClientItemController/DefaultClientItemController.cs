using System.Web.Http;
using FreemiumGameShop.ClientItem;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.ClientItemController
{
    [RoutePrefix("clients/items")]
    internal class DefaultClientItemController : ApiController
    {
        [Route("")]
        [HttpPost]
        public void CreateItem(int clientId, ClientItemCreateModel createModel)
        {
            ClientItemService.CreateItem(clientId, createModel);
        }

        [Route("code/{code}/update")]
        [HttpPut]
        public void UpdateItem(int clientId, string code, ClientItemCreateModel createModel)
        {
            ClientItemService.UpdateItem(clientId, code, createModel);
        }

        [Route("code/{code}/delete")]
        [HttpDelete]
        public void DeleteItem(int clientId, string code)
        {
            ClientItemService.DeleteItem(clientId, code);
        }

        [Route("code/{code}/get")]
        [HttpGet]
        public void GetItem(int clientId, string code)
        {
            ClientItemService.GetItem(clientId, code);
        }
    }
}
