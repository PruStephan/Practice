using System.Web.Http;

namespace Freemium.Game.Shop.Customer
{
    internal class CustomerController : ApiController
    {
        [Route("api/addcustomer/{name}")]
        [HttpPost]
        public void PostCustomer(int clientId, string name)
        {
            var cls = new CustomerService();
            cls.CreateCustomer(clientId);
        }

        [Route("api/purchase/{item_name}")]
        public void Purchase(int clienId, int customerId, string itemName)
        {
        }
    }
}
