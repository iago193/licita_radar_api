using LicitaRadarApi.Data;
using LicitaRadarApi.DTO;
using LicitaRadarApi.Exceptions;
using LicitaRadarApi.Helper;
using LicitaRadarApi.Token;

namespace LicitaRadarApi.Service;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly JWT _jwt;

    public AuthService(AppDbContext context, JWT jwt)
    {
        _context = context;
        _jwt = jwt;
    }
    public async Task<string> Login(DtoLoginRequest dto)
    {
        var resp = await _context.users.FindAsync(dto.Email);

        if(resp == null)
            throw AppException.Unauthorized("Credenciais inválidas");

        bool checkPassword = PasswordHelper.CheckPassword(dto.Password, resp.PasswordHash);

        if(!checkPassword)
            throw AppException.Unauthorized("Credenciais inválidas");

        string token = _jwt.GenerateToken(resp);

        return token;
    }
}