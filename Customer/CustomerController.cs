using System.Web.Http;

namespace FreemiumGameShop.Customer
{
    internal class CustomerController : ApiController
    {
        [Route("api/customer/{name}/add")]
        [HttpPost]
        public void PostCustomer(int clientId, string name)
        {
            var cls = new CustomerService();
            cls.CreateCustomer(clientId);
        }

        [Route("api/customer/{item_name}/purchase")]
        public void Purchase(int clienId, int customerId, string itemName)
        {
        }
    }
}
