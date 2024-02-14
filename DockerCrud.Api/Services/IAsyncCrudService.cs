using DockerCrud.Api.DTOs;
using DockerCrud.Api.Models;

namespace DockerCrud.Api.Services;

public interface IAsyncCrudService
{
    Task<UserDto> GetUserAsync(Guid id);
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto> AddUserAsync(AddUserRequestDto user);
    Task<UserDto> UpdateUserAsync(UpdateUserRequestDto user);
    Task<UserDto> DeleteUserAsync(Guid id);
}