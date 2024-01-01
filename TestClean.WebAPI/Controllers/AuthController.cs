using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using TestClean.Application.Dtos;
using TestClean.Infrastructure.Data;

namespace TestClean.WebAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _context;

    public AuthController(UserManager<IdentityUser> userManager, IdentityContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto regData)
    {
        var user = new IdentityUser { UserName = regData.Email, Email = regData.Email };
        var result = await _userManager.CreateAsync(user, regData.Password);

        if(result.Succeeded)
        {
            return Ok(new { message = "user registered successfully." });
        } else
        {
            return BadRequest(result.Errors);
        }

    }

}

