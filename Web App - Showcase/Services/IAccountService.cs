using Microsoft.AspNetCore.Mvc;
using Web_App___Showcase.Models;

namespace Web_App___Showcase.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
    }
}