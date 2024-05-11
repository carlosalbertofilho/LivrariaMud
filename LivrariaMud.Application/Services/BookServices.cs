using LivrariaMud.Application.Abstrations;
using LivrariaMud.Application.DTOs;
using LivrariaMud.Application.Exceptions;
using LivrariaMud.Application.Extensions;
using LivrariaMud.Application.Responses;
using LivrariaMud.Domain.Abstrations;

namespace LivrariaMud.Application.Services;

public class BookServices
    ( IBookRepository repository ) : IBookService
{
    private readonly IBookRepository _repository = repository;

    public async Task<IResponse<ViewBook>> CreateBookAsync ( EditBook book )
    {
        try
        {
            ViewBook newBook = await _repository.CreateAsync( book );
            return new SuccessResponse<ViewBook>( newBook );
        }
        catch ( BookException ex )
        {
            throw new( ex.Message );
        }
    }

    public async Task<IResponse<ViewBook>> DeleteBookAsync ( int id )
    {
        try
        {
            ViewBook book = await _repository.DeleteAsync( id );
            return new SuccessResponse<ViewBook>( book );
        } catch ( BookException ex )
        {
            throw new( ex.Message );
        }
    }

    public async Task<IResponse<IEnumerable<ViewBook>>> GetAllBooksAsync ()
    {
        try
        {
            var books = await _repository.GetAllAsync();
            IEnumerable<ViewBook> viewBooks 
                = books.Select( book => book.ToViewBook() );
            return new SuccessResponse<IEnumerable<ViewBook>>( viewBooks );
        }
        catch ( BookException ex )
        {
            throw new( ex.Message );
        }
    }

    public async Task<IResponse<ViewBook>> GetBookByIdAsync ( int id )
    {
        try
        {
            ViewBook book = await _repository.GetByIdAsync( id );
            return new SuccessResponse<ViewBook>( book );
        }
        catch ( BookException ex )
        {
            throw new( ex.Message );
        }
    }

    public async Task<IResponse<ViewBook>> UpdateBookAsync ( EditBook book )
    {
        try
        {
            ViewBook updatedBook = await _repository.UpdateAsync( book );
            return new SuccessResponse<ViewBook>( updatedBook );
        }
        catch ( BookException ex )
        {
            throw new( ex.Message );
        }
    }
}
