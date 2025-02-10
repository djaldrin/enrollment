// Controllers/AccountController.cs
using CodedKaratBackEnd.Models;
using CodedKaratBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    // POST api/account/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AccountRequestModel loginRequest)
    {
        if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
        {
            return BadRequest("Email and Password are required.");
        }

        var isValidLogin = await _accountService.LoginAsync(loginRequest.Email, loginRequest.Password);

        if (!isValidLogin)
        {
            return Unauthorized("Invalid credentials.");
        }

        return Ok("Login successful.");
    }

    // POST api/account/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AccountRequestModel accountRequest)
    {
        if (accountRequest == null || string.IsNullOrEmpty(accountRequest.Email) || string.IsNullOrEmpty(accountRequest.Password))
        {
            return BadRequest("Email and Password are required.");
        }

        var isCreated = await _accountService.CreateAccountAsync(accountRequest);

        if (!isCreated)
        {
            return Conflict("Email is already in use.");
        }

        return CreatedAtAction(nameof(Register), new { email = accountRequest.Email }, "Account created successfully.");
    }
}
