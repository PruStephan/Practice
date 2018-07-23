using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("CustomerItem")]
    internal class CustomerItem
    {
        public int Id { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("Price")]
        public double Price { get; set; }

        [Column("Code")]
        public string ItemCode { get; set; }

        [Column("ItemName")]
        public string Name { get; set; }
    }
}
