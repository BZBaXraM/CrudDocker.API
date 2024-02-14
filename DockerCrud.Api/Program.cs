using DockerCrud.Api.Data;
using DockerCrud.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CrudContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("Local")));
builder.Services.AddScoped<IAsyncCrudService, CrudService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<CrudContext>();
context.Database.Migrate();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
await app.RunAsync();