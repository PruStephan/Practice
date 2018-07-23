using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("ClientItem")]
    internal class ClientItem
    {
        [Column("Price")]
        public double Price { get; set; }

        [Column("ItemName")]
        public string Name { get; set; }

        public int Id { get; set; }
        
        [Column("Code")]
        public string Code { get; set; }

        [Column("ClientId")]
        public int ClientId { get; set; } 
    }
}
