using Ecom.Core.DTO;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Core.Sharing;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrastructure.Repositories;

public class AuthRepository(
    UserManager<AppUser> userManager,
    IEmailService emailService,
    SignInManager<AppUser> signInManager)
    : IAuth
{
    private readonly SignInManager<AppUser> _signInManager = signInManager;

    public async Task<string?> RegisterAsync(RegisterDto? registerDto)
    {
        if (registerDto == null)
            return null;
        if (await userManager.FindByNameAsync(registerDto.UserName) is not null)
            return "This Username is already registered";

        if (await userManager.FindByEmailAsync(registerDto.Email) is not null)
            return "This Email is already registered";
        AppUser user = new AppUser()
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName
        };
        var result = await userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded is not true)
            return result.Errors.ToList()[0].Description;
        // Send Active email
        string code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        await SendEmail(user.Email, code, "active", "ActiveEmail", "Please activate your account");
        return "Success";
    }

    public async Task SendEmail(string email, string code, string component, string subject, string message)
    {
        var result = new EmailDto(email, "hadymaageny@gmail.com", subject,
            EmailStringBody.Send(email, code, component, message));
        await emailService.SendEmail(result);
    }
}