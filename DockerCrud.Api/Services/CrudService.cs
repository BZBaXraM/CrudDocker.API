using DockerCrud.Api.Data;
using DockerCrud.Api.DTOs;
using DockerCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerCrud.Api.Services;

public class CrudService(CrudContext context) : IAsyncCrudService
{
    public async Task<UserDto> GetUserAsync(Guid id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return ConvertToDto(user!);
    }


    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await context.Users.ToListAsync();
        return users.Select(ConvertToDto);
    }


    public async Task<UserDto> AddUserAsync(AddUserRequestDto user)
    {
        var u = new User
        {
            Login = user.Login,
            Name = user.Name,
            Lastname = user.Lastname
        };
        await context.Users.AddAsync(u);
        await context.SaveChangesAsync();

        return ConvertToDto(u);
    }

    public async Task<UserDto> UpdateUserAsync(UpdateUserRequestDto user)
    {
        var u = new User
        {
            Login = user.Login,
            Name = user.Name,
            Lastname = user.Lastname
        };
        context.Users.Update(u);
        await context.SaveChangesAsync();

        return ConvertToDto(u);
    }

    public async Task<UserDto> DeleteUserAsync(Guid id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        context.Users.Remove(user!);
        await context.SaveChangesAsync();

        return ConvertToDto(user!);
    }

    private static UserDto ConvertToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Login = user.Login,
            Name = user.Name,
            Lastname = user.Lastname
        };
    }
}