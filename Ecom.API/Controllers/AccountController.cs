using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers;

public class AccountController : BaseController
{
    public AccountController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
    {
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _work.Auth.RegisterAsync(registerDto);
        if (!string.Equals(result, "success", StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest(new ResponseAPI<string>(400, result));
        }

        return Ok(new ResponseAPI<string>(200, result));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _work.Auth.LoginAsync(loginDto);
        if (result.StartsWith("Please"))
            return BadRequest(new ResponseAPI<string>(400, result));
        Response.Cookies.Append("token", result, new CookieOptions
        {
            Secure = true,
            HttpOnly = true,
            Domain = "localhost",
            Expires = DateTime.Now.AddDays(1),
            IsEssential = true,
            SameSite = SameSiteMode.Strict
        });
        return Ok(new ResponseAPI<string>(200, result));
    }

    [HttpPost("active-account")]
    public async Task<IActionResult> Active(ActivateAccountDto activateAccountDto)
    {
        var result = await _work.Auth.ActivateAccount(activateAccountDto);
        return result ? Ok(new ResponseAPI<string>(200)) :  BadRequest(new ResponseAPI<string>(400));
    }

    [HttpPost("send-email-forget-password")]
    public async Task<IActionResult> SendEmailForgetPassword(string email)
    {
        var result = await _work.Auth.SendEmailForForgetPassword(email);
        return result ? Ok(new ResponseAPI<string>(200)) :  BadRequest(new ResponseAPI<string>(400));
    }
}