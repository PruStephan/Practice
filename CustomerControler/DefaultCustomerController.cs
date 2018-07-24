using System.Web.Http;
using FreemiumGameShop.Customer;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.CustomerControler
{
    [RoutePrefix("client/{clientId}")]
    internal class DefaultCustomerController : ApiController
    {
        [Route("customers/{customerId}/items/{item_name}/purchase")]
        [HttpPut]
        public void Purchase(int clienId, int customerId, string itemCode)
        {
            var custs = new CustomerService();
            custs.ItemPurchase(clienId, customerId, itemCode);
        }

        [Route("customers/{customerId}/new/model/{model}")]
        [HttpPost]
        public void CreateCustomer(int clientId, CustomerModel model)
        {
            CustomerService.CreateCustomer(clientId, model);
        }

        [Route("customers/{customerId}/update/model/{model}")]
        [HttpPut]
        public void UpdateItem(int clientId, int customerId, CustomerModel model)
        {
            CustomerService.UpdateCustomer(clientId, customerId, model);
        }

        [Route("customers/{customerId}/delete")]
        [HttpDelete]
        public void DeleteItem(int clientId, int customerId)
        {
            CustomerService.Deletecustomer(clientId, customerId);
        }

        [Route("customers/{customerId}/{code}/get")]
        [HttpGet]
        public void GetItem(int clientId, int customerId)
        {
            CustomerService.GetItem(clientId, customerId);
        }

    }
}