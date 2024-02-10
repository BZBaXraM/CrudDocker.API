using DockerCrud.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerCrud.Api.Data;

public class CrudContext(DbContextOptions<CrudContext> options) : DbContext(options)
{
    public virtual DbSet<User> Users => Set<User>();
}