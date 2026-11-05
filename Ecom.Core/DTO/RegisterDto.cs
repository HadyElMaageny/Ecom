using System.Security.Cryptography.X509Certificates;

namespace Ecom.Core.DTO;


public record LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public record RegisterDto : LoginDto
{
    public string UserName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}

public record ResetPasswordDto: LoginDto
{
    public string Token { get; set; } = string.Empty;
}

public record ActivateAccountDto
{
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}