using LicitaRadarApi.Data;
using LicitaRadarApi.Model;

namespace LicitaRadarApi.Service;

public class UserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<string> createUser(UserModel user)
    {
        await _context.users.AddAsync(user);

        await _context.SaveChangesAsync();

        return "Usuário criado";
    }
}