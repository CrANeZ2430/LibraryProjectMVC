using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using Library.Persistence.LibraryDb;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors;

public class AuthorsRepository(LibraryDbContext dbContext) : IAuthorsRepository
{
    public async Task<Author> GetById(Guid authorId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Authors
            .FirstOrDefaultAsync(a => a.Id == authorId, cancellationToken);
    }

    public async Task AddAsync(Author author, CancellationToken cancellationToken = default)
    {
        await dbContext.Authors.AddAsync(author, cancellationToken);
    }

    public void Update(Author author)
    {
        dbContext.Authors.Update(author);
    }

    public void Remove(Author author)
    {
        dbContext.Authors.Remove(author);
    }
}
