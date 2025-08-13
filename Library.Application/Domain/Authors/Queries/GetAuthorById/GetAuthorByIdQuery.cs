using MediatR;

namespace Library.Application.Domain.Authors.Queries.GetAuthorById;

public record GetAuthorByIdQuery(
    Guid Id)
    : IRequest<AuthorDto>;
