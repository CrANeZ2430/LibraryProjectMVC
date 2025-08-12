using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Common;

public interface IBooksRepository
{
    Task<Book> GetById(Guid bookId, CancellationToken cancellationToken = default);
    Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken = default);
    Task AddAsync(Book book, CancellationToken cancellationToken = default);
    Task Update(Book book, CancellationToken cancellationToken = default);
    void Remove(Book book);
}
