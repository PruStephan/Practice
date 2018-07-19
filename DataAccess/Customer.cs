using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("Customer")]
    internal class Customer
    {
        [Column("Customer Wallet")]
        public double Ammount { get; set; }

        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ExternalId { get; set; }

        public ICollection<CustomerItem> Inventory{ get; set; }

    }
}
