using LivrariaMud.Application.Abstrations;

namespace LivrariaMud.Application.Responses;

public class SuccessResponse<T>
    ( T data ) : IResponse<T>
{
    public bool Status => true;
    public T Data { get; set; } = data;
}
