using DockerCrud.Api.Data;
using DockerCrud.Api.Models;
using DockerCrud.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DockerCrud.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(CrudContext context) : ControllerBase
{
    private readonly IAsyncCrudService _service = new CrudService(context);

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
        => Ok(await _service.GetUsersAsync());


    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserAsync(Guid id)
    {
        return Ok(await _service.GetUserAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync(User user)
    {
        return Ok(await _service.AddUserAsync(user));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync(User user)
    {
        return Ok(await _service.UpdateUserAsync(user));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        return Ok(await _service.DeleteUserAsync(id));
    }
}