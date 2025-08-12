using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using Library.Persistence.LibraryDb;

namespace Library.Infrastructure.Core.Domain.Authors;

public class AuthorsRepository(LibraryDbContext dbContext) : IAuthorsRepository
{
    public Task<Author> GetById(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Author author, CancellationToken cancellationToken = default)
    {
        await dbContext.Authors.AddAsync(author, cancellationToken);
    }

    public async Task Update(Author author, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(Author author)
    {
        throw new NotImplementedException();
    }
}
