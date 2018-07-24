using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreemiumGameShop.DataAccess
{
    [Table("CustomerItem")]
    internal class CustomerItem
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public double Price { get; set; }

        public string Code { get; set; }

         public string Name { get; set; }
    }
}
