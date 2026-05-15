namespace LicitaRadarApi.Model;

public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public int number_phone { get; set; }
    public string Address { get; set; }
    public string password_hash { get; set; }
    
}