using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Models;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Books;

public class BooksRepository(LibraryDbContext dbContext) : IBooksRepository
{
    public async Task<Book> GetById(Guid bookId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == bookId);
    }

    public async Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken = default)
    {
        return await dbContext.Books
            .FirstOrDefaultAsync(b => b.Isbn == isbn);
    }

    public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
    {
        await dbContext.Books.AddAsync(book);
    }

    public void Update(Book book)
    {
        dbContext.Books.Update(book);
    }

    public void Remove(Book book)
    {
        dbContext.Books.Remove(book);
    }
}
