using System.Web.Http;

namespace FreemiumGameShop.Customer
{
    internal class CustomerController : ApiController
    {
        [Route("{clientId}/customer/{customerName}/item/{item_name}/purchase")]
        [HttpPut]
        public void Purchase(int clienId, int customerId, string itemCode)
        {
            var custs = new CustomerService();
            custs.ItemPurchase(clienId, customerId, itemCode);
        }
    }
}
