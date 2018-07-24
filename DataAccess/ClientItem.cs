using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("ClientItem")]
    internal class ClientItem
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
        
        public string Code { get; set; }

        public int ClientId { get; set; } 
    }
}
