namespace licita_radar_api.Model;

public class User
{
    public int id { get; set; }
    public int name { get; set; }
    public int last_name { get; set; }
    public int email { get; set; }
    public int password_hash { get; set; }
}