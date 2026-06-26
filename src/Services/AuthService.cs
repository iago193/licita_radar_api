using LicitaRadarApi.Data;
using LicitaRadarApi.DTO;
using LicitaRadarApi.Exceptions;
using LicitaRadarApi.Helper;

namespace LicitaRadarApi.Service;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }
    public async Task Login(DtoLoginRequest dto)
    {
        var resp = await _context.users.FindAsync(dto.Email);

        if(resp == null)
            throw AppException.Unauthorized("Credenciais inválidas");

        bool checkPassword = PasswordHelper.CheckPassword(dto.Password, resp.PasswordHash);

        if(!checkPassword)
            throw AppException.Unauthorized("Credenciais inválidas");

    }
}