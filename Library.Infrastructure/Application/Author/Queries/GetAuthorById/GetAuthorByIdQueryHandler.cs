using Library.Application.Domain.Authors.Queries.GetAuthorById;
using Library.Core.Domain.Authors.Common;
using MediatR;

namespace Library.Infrastructure.Application.Author.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler(
    IAuthorsRepository authorsRepository)
    : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    public async Task<AuthorDto> Handle(
        GetAuthorByIdQuery query, 
        CancellationToken cancellationToken = default)
    {
        var author = await authorsRepository.GetById(query.Id, cancellationToken);

        return new AuthorDto(
            author.FirstName,
            author.LastName,
            author.Middlename,
            author.Biography,
            author.ImageUrl);
    }
}
