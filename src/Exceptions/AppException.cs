namespace LicitaRadarApi.Exceptions;

public class AppException : Exception
{
    public int StatusCode { get; }

    public AppException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    // 404
    public static AppException NotFound(string message)
        => new(message, 404);

    public static AppException NotFound(string entityName, object id)
        => new($"{entityName} com id '{id}' não foi encontrado.", 404);

    public static AppException NotFound(string entityName, string field, object value)
        => new($"{entityName} com {field} '{value}' não foi encontrado.", 404);

    public static AppException NotFound(Type entityType, object id)
        => new($"{entityType.Name} com id '{id}' não foi encontrado.", 404);

    // 400
    public static AppException BadRequest(string message)
        => new(message, 400);

    // 401
    public static AppException Unauthorized(string message = "Não autorizado.")
        => new(message, 401);

    // 403
    public static AppException Forbidden(string message = "Acesso negado.")
        => new(message, 403);

    // 409
    public static AppException Conflict(string message)
        => new(message, 409);

    public static AppException Conflict(string entityName, string field, object value)
        => new($"{entityName} com {field} '{value}' já existe.", 409);

    // 422
    public static AppException UnprocessableEntity(string message)
        => new(message, 422);
}