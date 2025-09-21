using E_Commerce_Inventory_API.Src.Domain.Models;

namespace E_Commerce_Inventory_API.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> UserRegister(UserModel user);
        Task<UserModel> GetByEmail(string email);
        Task<UserModel> UserLogin(string email, string password);
       

    }
}
