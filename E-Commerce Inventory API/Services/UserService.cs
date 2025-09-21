using E_Commerce_Inventory_API.Interfaces;
using E_Commerce_Inventory_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_Inventory_API.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public async Task<UserModel> UserRegister(UserModel user)
        {
            var existingUser = await _unitOfWork.Users.GetByEmail(user.Email);
            if (existingUser != null)
                throw new ArgumentException("User already exists with this email.");

            var passwordHasher = new PasswordHasher<UserModel>();
            user.Password = passwordHasher.HashPassword(user, user.Password);

            var newUser = await _unitOfWork.Users.UserRegister(user);
            await _unitOfWork.CompleteAsync();
            return newUser;
        }

      
        public async Task<UserModel> UserLogin(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByEmail(email);
            if (user == null)
                return null;

            var passwordHasher = new PasswordHasher<UserModel>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Success)
                return user;

            return null;
        }
       


    }
}
