using System.ComponentModel.DataAnnotations.Schema;

namespace Freemium.Game.Shop.InvetntoryItem
{
    [Table("Customer Item")]
    internal class CustomerItem
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int CustomerId { get; set; }

        public double Price { get; set; }

        [Column ("Item Name")]
        public string Name { get; set; }
    }
}


