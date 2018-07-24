using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("Customer")]
    internal class Customer
    {
        public double Ammount { get; set; }

        public int Id { get; set; }

        public string Nickname { get; set; }

        public int ClientId { get; set; }

        public int ExternalId { get; set; }

        public ICollection<CustomerItem> Inventory { get; set; }
    }
}
