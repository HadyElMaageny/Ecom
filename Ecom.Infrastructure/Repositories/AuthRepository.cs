using Ecom.Core.DTO;
using Ecom.Core.Entities;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Core.Sharing;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrastructure.Repositories;

public class AuthRepository(
    UserManager<AppUser> userManager,
    IEmailService emailService,
    SignInManager<AppUser> signInManager,
    IGenerateToken generateToken)
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
            UserName = registerDto.UserName,
            DisplayName = registerDto.DisplayName,
        };
        var result = await userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded is not true)
            return result.Errors.ToList()[0].Description;
        // Send Active email
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        await SendEmail(user.Email, token, "active", "ActiveEmail", "Please activate your account");
        return "Success";
    }

    public async Task SendEmail(string email, string code, string component, string subject, string message)
    {
        var result = new EmailDto(email, "hadymaageny@gmail.com", subject,
            EmailStringBody.Send(email, code, component, message));
        await emailService.SendEmail(result);
    }

    public async Task<string?> LoginAsync(LoginDto? loginDto)
    {
        if (loginDto == null) return null;
        var findUser = await userManager.FindByEmailAsync(loginDto.Email);
        if (findUser is null)
            return "Please check your email and password, something went wrong";
        if (!findUser.EmailConfirmed)
        {
            // Generate new confirmation token
            var token = await userManager.GenerateEmailConfirmationTokenAsync(findUser);
            // Send confirmation email again
            await SendEmail(findUser.Email, token, "active", "ActiveEmail", "Please activate your account");
            return "Please confirm your email, we sent you a new activation link";
        }

        var result = await _signInManager.CheckPasswordSignInAsync(findUser, loginDto.Password, true);

        if (result.Succeeded)
            return generateToken.GetAndCreateToken(findUser);
        return "Please check your email and password, something went wrong";
    }

    public async Task<bool> SendEmailForForgetPassword(string email)
    {
        var findUser = await userManager.FindByEmailAsync(email);

        if (findUser is null)
        {
            return false;
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(findUser);
        await SendEmail(findUser.Email, token, "Reset-Password", "Reset Password",
            "click button to reset your password");
        return true;
    }

    public async Task<string> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        var findUser = await userManager.FindByEmailAsync(resetPasswordDto.Email);
        if (findUser is null)
            return null;

        var result = await userManager.ResetPasswordAsync(findUser, resetPasswordDto.Token, resetPasswordDto.Password);
        if (result.Succeeded)
            return "Password Changed Successfully";
        return result.Errors.First().Description;
    }

    public async Task<bool> ActivateAccount(ActivateAccountDto activateAccountDto)
    {
        var findUser = await userManager.FindByEmailAsync(activateAccountDto.Email);
        if (findUser is null)
            return false;
        var result = await userManager.ConfirmEmailAsync(findUser, activateAccountDto.Token);

        if (result.Succeeded)
            return true;

        string token = await userManager.GenerateEmailConfirmationTokenAsync(findUser);
        await SendEmail(findUser.Email, token, "active", "ActiveEmail", "Please activate your account");
        return false;
    }
}