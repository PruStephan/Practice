using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("Client")]
    internal class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column]
        public ICollection<Customer> Customers { get; set; }

        [Column]
        public ICollection<ShopItem> Items{ get; set; }
    }
}
