namespace E_Commerce_Inventory_API.DTOS
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
