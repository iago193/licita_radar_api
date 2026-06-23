using LicitaRadarApi.Data;
using LicitaRadarApi.DTO;
using LicitaRadarApi.Exceptions;
using LicitaRadarApi.Model;

namespace LicitaRadarApi.Service;

public class UserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<object> createUser(DtoUser dto)
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

        return new
        {
            message = "Usuário criado com sucesso!"
        };
    }

    public async Task<DtoUserGet?> getById(int id)
    {
        var resp = await _context.users.FindAsync(id);
        if (resp == null)
        {
            throw new NotFoundException("Usuário não encontrado");
        }

        return new DtoUserGet
        {
            Id = resp.Id,
            Name = resp.Name,
            LastName = resp.LastName,
            Email = resp.Email,
            NumberPhone = resp.NumberPhone
        };
    }

    public async Task<object> update(int id)
    {
        return new
        {
            message = "Usuário editado com sucesso!"
        };
    }
}