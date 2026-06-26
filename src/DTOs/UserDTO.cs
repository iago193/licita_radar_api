namespace LicitaRadarApi.DTO;

public class DtoBase
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string NumberPhone { get; set; }
}
public class DtoUser: DtoBase
{
    public string Password { get; set; }
    public string PasswordRepeat { get; set; }
}

public class UpdateDtoUser : DtoBase
{
}

public class DtoUserGet : DtoBase
{
    public int Id { get; set; }
}

public class DtoLoginRequest
{
    public string Email {get; set; }
    public string Password {get; set; }
}