using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuth.Services.Abstractions;
using SimpleAuth.Contracts.Dto;

namespace SimpleAuth.Presentation.Controllers;

/// <summary>
/// The user controller.
/// </summary>
[Route("/users")]
public class UserController: ControllerBase
{
    private IUserService service { get; }

    public UserController(IUserService service) => this.service = service;


    /// <summary>
    /// Adds a user to the database.
    /// </summary>
    /// <param name="user">The user's details needed.</param>
    /// <returns></returns>
    [HttpPost("/register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] AddUserRequest user) 
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(o => o.ErrorMessage));
            return BadRequest(new
            {
                Message = message,
                StatusCode= 400,
            });
        }

        try
        {
            var result = await service.Register(user);
            return result ? Ok("Account created successfully.") : StatusCode(500, new
            {
                Message = "Could not process your request.",
                StatusCode = 501,
            });
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                Message = e.Message,
                StatusCode = 400,
            });
        }
    }

    /// <summary>
    /// Login users.
    /// </summary>
    /// <param name="userDetails">The login details of the user.</param>
    /// <returns></returns>
    [HttpPost("/login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest userDetails)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(o => o.ErrorMessage));
            return BadRequest(new
            {
                Message = message,
                StatusCode = 400,
            });
        }

        try
        {
            return Ok(await service.Login(userDetails));
        }
        catch (Exception e)
        {
            return Unauthorized(new
            {
                Message = e.Message,
                StatusCode = 401,
            });
        }
    }
}
