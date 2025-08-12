using Library.Application.Common;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using Library.Persistence.LibraryDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Author.Queries.GetAuthors;

public class GetAuthorsQueryHandler(
    LibraryDbContext dbContext)
    : IRequestHandler<GetAuthorsQuery, PageResponse<AuthorDto[]>>
{
    public async Task<PageResponse<AuthorDto[]>> Handle(GetAuthorsQuery query, CancellationToken cancellationToken = default)
    {
        var skip = query.PageSize * (query.Page - 1);

        var sqlQuery = dbContext.Authors
            .AsNoTracking()
            .OrderBy(a => a.FirstName)
            .Select(a => new AuthorDto(
                a.Id,
                a.FirstName,
                a.LastName,
                a.Middlename,
                a.Biography,
                a.ImageUrl))
            .Skip(skip)
            .Take(query.PageSize);

        var authors = await sqlQuery.ToArrayAsync(cancellationToken);
        var count = authors.Count();

        return new PageResponse<AuthorDto[]>(count, authors);
    }
}
