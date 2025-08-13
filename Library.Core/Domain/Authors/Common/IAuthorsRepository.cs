using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Authors.Common;

public interface IAuthorsRepository
{
    Task<Author> GetById(Guid userId, CancellationToken cancellationToken = default);
    Task<Author[]> GetByIds(Guid[] authorIds, CancellationToken cancellationToken = default);
    Task AddAsync(Author author, CancellationToken cancellationToken = default);
    void Update(Author author);
    void Remove(Author author);
}
