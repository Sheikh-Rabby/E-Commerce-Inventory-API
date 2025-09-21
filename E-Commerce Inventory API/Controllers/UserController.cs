using E_Commerce_Inventory_API.DTOS;
using E_Commerce_Inventory_API.Models;
using E_Commerce_Inventory_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Inventory_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Authorize]
    public class UserController :ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public UserController(UserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserModel user)
        {



            try
            {
                var adduser = await _userService.UserRegister(user);


                return Ok(new
                {
                    Message = "User Register successfully",
                    Data = adduser
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginRequest request)
        {



            try
            {
                var user = await _userService.UserLogin(request.Email,request.Password);

                if (user == null)

                    return Unauthorized("Invalid id Or Password");

                var token = _jwtService.GenerateJwtToken(user);

                var refreshToken = _jwtService.GenerateRefreshToken();


                var response = new LoginResponse
                {
                    Message = "User login successful",
                    Token = token,
                    RefreshToken = refreshToken.Token
                };
                return Ok(response);

                //return Ok(new
                //{
                //    Message = "User login successful",
                //    token = token,
                //    refreshtoken= refreshToken
                //});
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }







    }
}
