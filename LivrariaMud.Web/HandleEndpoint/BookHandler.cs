using LivrariaMud.Application.Abstrations;
using LivrariaMud.Application.DTOs;
using LivrariaMud.Application.Exceptions;

namespace LivrariaMud.Web.HandleEndpoint;

public class BookHandler
    ( IBookService bookService )
{
    private readonly IBookService repository = bookService;
    private bool? Status = null;
    private ViewBook? Data;
    private IEnumerable<ViewBook> DataList = [];
    private List<string> Errors = [];

    public async Task<(bool? Status, IEnumerable<ViewBook> dataList, List<string> errors)> GetAllBooksHandler ()
    {
        try
        {
            var response = await repository.GetAllBooksAsync();
            Status = response.Status;
            DataList = response.Data;
            return ( Status, DataList, Errors );
        }
        catch ( BookException be )
        {
            Status = be.ErrorResponse.Status;
            Errors = be.ErrorResponse.Data;
            Errors.Add( be.Message );
            return ( Status, DataList, Errors );
        }
        catch ( Exception e )
        {
            Status = false;
            Errors.Add( e.Message );
            return ( Status, DataList, Errors );
        }
    }
    public async Task<(bool? Status, ViewBook? Data, List<string> Errors)> GetBookByIdHandler ( int BookId )
    {
        try
        {
            var response = await repository.GetBookByIdAsync(BookId);
            Status = response.Status;
            Data = response.Data;
            return (Status, Data, Errors);
        }
        catch ( BookException be )
        {
            Status = be.ErrorResponse.Status;
            Errors = be.ErrorResponse.Data;
            Errors.Add( be.Message );
            return (Status, Data, Errors);
        }
        catch ( Exception e )
        {
            Status = false;
            Errors.Add( e.Message );
            return (Status, Data, Errors);
        }
    }
    public async Task<(bool? Status, ViewBook? Data, List<string> Errors)> CreateBookHandler ( EditBook book )
    {
        try
        {
            var response = await repository.CreateBookAsync( book );
            Status = response.Status;
            Data = response.Data;
            return (Status, Data, Errors);
        }
        catch ( BookException be )
        {
            Status = be.ErrorResponse.Status;
            Errors = be.ErrorResponse.Data;
            Errors.Add( be.Message );
            return (Status, Data, Errors);
        }
        catch ( Exception e )
        {
            Status = false;
            Errors.Add( e.Message );
            return (Status, Data, Errors);
        }
    }

    public async Task<(bool? Status, ViewBook? Data, List<string> Errors)> UpdateBookHandler ( EditBook book )
    {
        try
        {
            var response = await repository.UpdateBookAsync( book );
            Status = response.Status;
            Data = response.Data;
            return (Status, Data, Errors);
        }
        catch ( BookException be )
        {
            Status = be.ErrorResponse.Status;
            Errors = be.ErrorResponse.Data;
            Errors.Add( be.Message );
            return (Status, Data, Errors);
        }
        catch ( Exception e )
        {
            Status = false;
            Errors.Add( e.Message );
            return (Status, Data, Errors);
        }
    }

    public async Task<(bool? Status, ViewBook? Data, List<string> Errors)> DeleteBookHandler ( int BookId )
    {
        try
        {
            var response = await repository.DeleteBookAsync( BookId );
            Status = response.Status;
            Data = response.Data;
            return (Status, Data, Errors);
        }
        catch ( BookException be )
        {
            Status = be.ErrorResponse.Status;
            Errors = be.ErrorResponse.Data;
            Errors.Add( be.Message );
            return (Status, Data, Errors);
        }
        catch ( Exception e )
        {
            Status = false;
            Errors.Add( e.Message );
            return (Status, Data, Errors);
        }
    }
}