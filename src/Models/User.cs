namespace LicitaRadarApi.Model;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int NumberPhone { get; set; }
    public string PasswordHash { get; set; }
    
}