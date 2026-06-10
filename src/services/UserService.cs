using LicitaRadarApi.Data;
using LicitaRadarApi.DTO;
using LicitaRadarApi.Model;

namespace LicitaRadarApi.Service;

public class UserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<string> createUser(DtoUser dto)
    {
        var user = new UserModel
        {
            Name = dto.Name,
            LastName = dto.LastName,
            Email = dto.Email,
            NumberPhone = dto.NumberPhone,
            PasswordHash = dto.Password
        };

        await _context.users.AddAsync(user);
        
        await _context.SaveChangesAsync();

        return "Usuário criado";
    }
}