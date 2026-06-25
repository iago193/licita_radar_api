using LicitaRadarApi.Data;
using LicitaRadarApi.DTO;
using LicitaRadarApi.Exceptions;
using LicitaRadarApi.Model;
using LicitaRadarApi.Validators;

namespace LicitaRadarApi.Service;

public class UserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<object> CreateUser(DtoUserCreate dto)
    {
        var validator = new CreateUserRequestValidator();
        var result = validator.Validate(dto);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw AppException.BadRequest(string.Join(", ", errors));
        }

        if(dto.Password != dto.PasswordRepeat) 
            throw AppException.Unauthorized("As senhas não coincidem.");

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

    public async Task<DtoUserGet?> GetUserById(int id)
    {
        var resp = await _context.users.FindAsync(id);

        if (resp == null)
            throw AppException.NotFound("Usuário não encontrado");

        return new DtoUserGet
        {
            Id = resp.Id,
            Name = resp.Name,
            LastName = resp.LastName,
            Email = resp.Email,
            NumberPhone = resp.NumberPhone
        };
    }

    public async Task Update(int id, UpdateDtoUser dto)
    {
        var validator = new UpdateUserRequestValidator();
        var result = validator.Validate(dto);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw AppException.BadRequest(string.Join(", ", errors));
        }

        var user = await _context.users.FindAsync(id);

        if (user == null)
            throw AppException.NotFound("Usuário não encontrado");

        user.Name = string.IsNullOrWhiteSpace(dto.Name) ? user.Name : dto.Name;
        user.LastName = string.IsNullOrWhiteSpace(dto.LastName) ? user.LastName : dto.LastName;
        user.Email = string.IsNullOrWhiteSpace(dto.Email) ? user.Email : dto.Email;
        user.NumberPhone = string.IsNullOrWhiteSpace(dto.NumberPhone) ? user.NumberPhone : dto.NumberPhone;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.users.FindAsync(id);

        if (user == null)
            throw AppException.NotFound("Usuário não encontrado");

        _context.users.Remove(user);

        await _context.SaveChangesAsync();
    }
}