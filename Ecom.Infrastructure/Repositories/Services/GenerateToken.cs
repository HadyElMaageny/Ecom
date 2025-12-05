using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ecom.Core.Entities;
using Ecom.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ecom.Infrastructure.Repositories.Services;

public class GenerateToken : IGenerateToken
{
    private readonly IConfiguration _configuration;

    public GenerateToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetAndCreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
        };
        
        var secret = _configuration["Token:Secret"];
        var key = Encoding.ASCII.GetBytes(secret);
        
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(3),
            Issuer = _configuration["Token:Issuer"],
            SigningCredentials = credentials
        };

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}