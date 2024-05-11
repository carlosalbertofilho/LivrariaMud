using LivrariaMud.Application.Abstrations;

namespace LivrariaMud.Application.Responses;

public class ErrorResponse : IResponse<List<string>>
{
    public bool Status => false;
    public List<string> Data { get; set; } = [];

    public ErrorResponse ( string message )
        => Data.Add( message );
}
