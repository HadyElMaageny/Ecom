namespace Ecom.Core.DTO;


public record LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public record RegisterDto : LoginDto
{
    public string UserName { get; set; } = string.Empty;
}