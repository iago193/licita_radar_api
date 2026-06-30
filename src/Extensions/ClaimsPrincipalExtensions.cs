using System.Security.Claims;

namespace LicitaRadarApi.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(id!);
    }

    public static string GetUserName(this ClaimsPrincipal user)
        => user.FindFirst(ClaimTypes.Name)?.Value!;

    public static string GetUserEmail(this ClaimsPrincipal user)
        => user.FindFirst(ClaimTypes.Email)?.Value!;
}