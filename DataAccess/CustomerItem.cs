using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("Customer Item")]
    internal class CustomerItem
    {
        public int Id { get; set; }

//        [ForeignKey("Client")]
        public int ClientId { get; set; }

       // [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public double Price { get; set; }

        public string ItemCode { get; set; }

        [Column ("Item Name")]
        public string Name { get; set; }
    }
}


