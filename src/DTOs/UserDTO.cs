namespace LicitaRadarApi.DTO;

public class DtoUserCreate
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
    public string Password { get; set; }
}

public class UpdateDtoUser
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? NumberPhone { get; set; }
}

public class DtoUserGet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
}