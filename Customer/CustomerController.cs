using System.Web.Http;

namespace FreemiumGameShop.Customer
{
    [RoutePrefix("client/{clientId}/customers/{customerId}")]
    internal class CustomerController : ApiController
    {
        [Route("items/{item_name}/purchase")]
        [HttpPut]
        public void Purchase(int clienId, int customerId, string itemCode)
        {
            var custs = new CustomerService();
            custs.ItemPurchase(clienId, customerId, itemCode);
        }
    }
}