using System.ComponentModel.DataAnnotations;
namespace E_Commerce_Inventory_API.Models
{
    public class UserModel
    {
        [Key]
        public int userID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Username { get; set; } 
    }
}
