using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Models;

namespace Library.Infrastructure.Core.Domain.Books;

public class BooksRepository : IBooksRepository
{
    public Task<Book> GetById(Guid bookId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Book book, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task Update(Book book, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(Book book)
    {
        throw new NotImplementedException();
    }
}
