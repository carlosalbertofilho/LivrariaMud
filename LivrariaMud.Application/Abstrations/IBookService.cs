using LivrariaMud.Application.DTOs;

namespace LivrariaMud.Application.Abstrations;

public interface IBookService
{
    Task<IResponse<IEnumerable<ViewBook>>> GetAllBooksAsync();
    Task<IResponse<ViewBook>> GetBookByIdAsync( int id );
    Task<IResponse<ViewBook>> CreateBookAsync( EditBook book );
    Task<IResponse<ViewBook>> UpdateBookAsync( EditBook book );
    Task<IResponse<ViewBook>> DeleteBookAsync( int id );
}