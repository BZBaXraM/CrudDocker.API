using DockerCrud.Api.Models;

namespace DockerCrud.Api.Services;

public interface IAsyncCrudService
{
    Task<User> GetUserAsync(Guid id);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(Guid id);
}