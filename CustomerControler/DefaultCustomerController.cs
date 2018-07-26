using System.Web.Http;
using FreemiumGameShop.Customer;
using FreemiumGameShop.DataModels;

namespace FreemiumGameShop.CustomerControler
{
    [RoutePrefix("clients/customers")]
    internal class DefaultCustomerController : ApiController
    {
        [Route("{customerId}/items/code/{itemCode}/purchase")]
        [HttpPut]
        public void Purchase(int clienId, int customerId, string itemCode)
        {
            var custs = new CustomerService();
            custs.ItemPurchase(clienId, customerId, itemCode);
        }

        [Route("")]
        [HttpPost]
        public void CreateCustomer(int clientId, CustomerCreateModel model)
        {
            CustomerService.CreateCustomer(clientId, model);
        }

        [Route("{customerId}/update")]
        [HttpPut]
        public void UpdateItem(int clientId, int customerId, CustomerCreateModel model)
        {
            CustomerService.UpdateCustomer(clientId, customerId, model);
        }

        [Route("{customerId}/delete")]
        [HttpDelete]
        public void DeleteItem(int clientId, int customerId)
        {
            CustomerService.Deletecustomer(clientId, customerId);
        }

        [Route("{customerId}/code/{code}/get")]
        [HttpGet]
        public void GetItem(int clientId, int customerId)
        {
            CustomerService.GetItem(clientId, customerId);
        }

    }
}