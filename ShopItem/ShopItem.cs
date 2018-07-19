using System.ComponentModel.DataAnnotations.Schema;

namespace Freemium.Game.Shop.ShopItem
{
    [Table("Shop Item")]
    internal class ShopItem
    {
        [Column("Item Price")]
        public double Price { get; set; }

        [Column("Item Name")]
        public string Name { get; set; }

        public int Id { get; set; }

        public int ClientId { get; set; } 
    }
}
