using E_Commerce_Inventory_API.data;
using E_Commerce_Inventory_API.Interfaces;
using E_Commerce_Inventory_API.Interfaces.Repositories;
using E_Commerce_Inventory_API.Models;
using E_Commerce_Inventory_API.Repositories;


namespace E_Commerce_Inventory_API.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categorys = new CategoryRepository(_context);
            Users     = new UserRepository(_context);
        }
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categorys { get; private set; }
        public IUserRepository Users { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
