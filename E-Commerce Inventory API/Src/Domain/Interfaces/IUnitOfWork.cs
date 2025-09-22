using E_Commerce_Inventory_API.Interfaces.Repositories;

namespace E_Commerce_Inventory_API.Src.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categorys { get; }
        IUserRepository Users { get; }

        Task<int> CompleteAsync();
    }
}
