using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace E_Commerce_Inventory_API.Src.Domain.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
