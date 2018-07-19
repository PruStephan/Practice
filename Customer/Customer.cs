using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Freemium.Game.Shop.InvetntoryItem;

namespace Freemium.Game.Shop.Customer
{
    [Table("Customer")]
    internal class Customer
    {
        [Column("Customer Wallet")]
        public double Ammount { get; set; }

        public int Id { get; set; }

        public int Client_Id { get; set; }

        public int ExternalId { get; set; }

        [Column("Customer Inventory")]
        public ICollection<CustomerItem> Inventory{ get; set; }

    }
}
