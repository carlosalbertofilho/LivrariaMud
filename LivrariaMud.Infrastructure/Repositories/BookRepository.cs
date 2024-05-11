using LivrariaMud.Domain.Abstrations;
using LivrariaMud.Domain.Entities;
using LivrariaMud.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LivrariaMud.Infrastructure.Repositories;

public class BookRepository
    ( LivrariaMudContext mudContext ) : IBookRepository
{
    private readonly LivrariaMudContext context = mudContext;
    public async Task<IEnumerable<Book>> GetAllAsync ()
    {
        try
        {
            return await context.Books.AsNoTracking().ToListAsync();
        }
        catch
        {
            throw new ( "Falha ao buscar os livros" );
        }
    }

    public async Task<Book> GetByIdAsync ( int id )
    {
        try
        {
            var book = await context.Books.FindAsync( id );
            return book is null 
                ? throw new( "Livro não encontrado" ) 
                : book;
        }
        catch ( DbUpdateConcurrencyException )
        {
            throw new( "Falha ao deletar o livro" );
        }
        catch ( DbUpdateException )
        {
            throw new( "Falha ao deletar o livro" );
        }
        catch ( Exception e )
        {
            throw new( e.Message );
        }
    }
    public async Task<Book> CreateAsync ( Book book )
    {
        try
        {
            await context.Books.AddAsync( book );
            await context.SaveChangesAsync();
            return book;
        }
        catch
        {
            throw new ( "Falha ao criar o livro" );
        }

    }

    public async Task<Book> DeleteAsync ( int id )
    {
        try
        {
            var book = await context.Books.FindAsync( id ) 
                ?? throw new ( "Livro não encontrado" );
            context.Books.Remove( book );
            await context.SaveChangesAsync();
            return book;
        }
        catch ( DbUpdateConcurrencyException )
        {
            throw new( "Falha ao deletar o livro" );
        }
        catch ( DbUpdateException )
        {
            throw new( "Falha ao deletar o livro" );
        }
        catch ( Exception e )
        {
            throw new( e.Message );
        }
    }


    public async Task<Book> UpdateAsync ( Book book )
    {
        try
        {
            var bookToUpdate = await context.Books.FindAsync( book.Id ) 
                ?? throw new ( "Livro não encontrado" );
            context.Entry( bookToUpdate ).CurrentValues.SetValues( book );
            await context.SaveChangesAsync();
            return book;
        }
        catch ( DbUpdateConcurrencyException )
        {
            throw new ( "Falha ao atualizar o livro" );
        }
        catch ( DbUpdateException )
        {
            throw new ( "Falha ao atualizar o livro" );
        }
        catch ( Exception e )
        {
            throw new ( e.Message );
        }
    }
}
