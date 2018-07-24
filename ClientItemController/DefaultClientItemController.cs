using System.Web.Http;
using FreemiumGameShop.ClientItem;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.ClientItemController
{
    [RoutePrefix("clients/{clientId}/items")]
    internal class DefaultClientItemController : ApiController
    {
        [Route("new/model/{model}")]
        [HttpPost]
        public void CreateItem(int clientId, ClientItemModel model)
        {
            ClientItemService.CreateItem(clientId, model);
        }

        [Route("code/{code}/update/model/{model}")]
        [HttpPut]
        public void UpdateItem(int clientId, string code, ClientItemModel model)
        {
            ClientItemService.UpdateItem(clientId, code, model);
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
