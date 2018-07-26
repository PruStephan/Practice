using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("Client")]
    internal class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ICollection<ClientItem> Items { get; set; }
    }
}
