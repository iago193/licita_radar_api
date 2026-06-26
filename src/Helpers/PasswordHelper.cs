using BC = BCrypt.Net.BCrypt;

namespace LicitaRadarApi.Helper;

public class PasswordHelper
{
    public static string GenerateHashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public static bool CheckPassword(string password, string hash)
    {
        return BC.Verify(password, hash);
    }
}