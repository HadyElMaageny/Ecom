using Ecom.Core.DTO;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrastructure.Repositories;

public class AuthRepository : IAuth
{
    private readonly UserManager<AppUser> _userManager;

    public AuthRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        if (registerDto == null)
            return null;
        if (await _userManager.FindByNameAsync(registerDto.UserName) is not null)
            return "This Username is already registered";

        if (await _userManager.FindByEmailAsync(registerDto.Email) is not null)
            return "This Email is already registered";
        AppUser user = new AppUser()
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName
        };
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded is not true)
            return result.Errors.ToList()[0].Description;
        // Send Active email
        return "Success";
    }
}