using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuth.Services.Abstractions;
using SimpleAuth.Contracts.Dto;

namespace SimpleAuth.Presentation.Controllers;

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
    public async Task<IActionResult> AddUser(AddUserRequest user) 
    {
        try
        {
            var result = await service.Add(user);
            return result ? Ok() : StatusCode(500, new
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
    /// Authenticates users.
    /// </summary>
    /// <param name="userDetails">The login details of the user.</param>
    /// <returns></returns>
    [HttpPost("/authenticate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate(VerifyUserRequest userDetails)
    {
        try
        {
            return Ok(await service.Verify(userDetails));
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
