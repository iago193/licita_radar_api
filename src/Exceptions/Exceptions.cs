using LicitaRadarApi.Exceptions_app;
namespace LicitaRadarApi.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message)
        : base(message, 404) { }
}