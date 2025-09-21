using E_Commerce_Inventory_API.data;
using E_Commerce_Inventory_API.Interfaces.Repositories;
using E_Commerce_Inventory_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Inventory_API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

  
        public async Task<UserModel> UserRegister(UserModel user)
        {
           
            await _context.Users.AddAsync(user);
            return user;
        }

      
        public async Task<UserModel> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        
        public async Task<UserModel> UserLogin(string email, string password)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
                return null; 

            
            var passwordHasher = new PasswordHasher<UserModel>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Success)
            {
                
                return user;
            }

            
            return null;
        }
    }
}
