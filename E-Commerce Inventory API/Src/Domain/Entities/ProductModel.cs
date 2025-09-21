using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Commerce_Inventory_API.Src.Domain.Models
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; } 
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public string? Image { get; set; }
       

    }
}
