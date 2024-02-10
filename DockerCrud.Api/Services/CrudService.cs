using DockerCrud.Api.Data;
using DockerCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerCrud.Api.Services;

public class CrudService(CrudContext context) : IAsyncCrudService
{
    public async Task<User> GetUserAsync(Guid id)
        => (await context.Users.FirstOrDefaultAsync(x => x.Id == id))!;


    public async Task<IEnumerable<User>> GetUsersAsync()
        => await context.Users.ToListAsync();


    public async Task<User> AddUserAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<User> DeleteUserAsync(Guid id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        context.Users.Remove(user!);
        await context.SaveChangesAsync();

        return user!;
    }
}