using E_Commerce_Inventory_API.Src.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_Inventory_API.data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categorys { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
