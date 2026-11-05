using Ecom.Core.DTO;

namespace Ecom.Core.Interfaces;

public interface IAuth
{
    Task<string?> RegisterAsync(RegisterDto? registerDto);
    Task<string?> LoginAsync(LoginDto? loginDto);
    Task SendEmail(string email, string code, string component, string subject, string message);
    Task<string> ResetPassword(ResetPasswordDto resetPasswordDto);
    Task<bool> ActivateAccount(ActivateAccountDto activateAccountDto);
    Task<bool> SendEmailForForgetPassword(string email);
}