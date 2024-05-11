using LivrariaMud.Domain.Entities;

namespace LivrariaMud.Domain.Abstrations;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(Guid id);
    Task<Book> CreateAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<Book> DeleteAsync ( Guid id );
}
