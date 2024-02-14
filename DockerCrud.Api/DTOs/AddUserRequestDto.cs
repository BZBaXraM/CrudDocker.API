namespace DockerCrud.Api.DTOs;

public class AddUserRequestDto
{
    public string Login { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}