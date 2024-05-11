using LivrariaMud.Application.Responses;

namespace LivrariaMud.Application.Exceptions;

public class BookException 
    ( string message ) :  Exception( message )
{
    public ErrorResponse ErrorResponse { get; private set; } 
        = new ( message );
}
