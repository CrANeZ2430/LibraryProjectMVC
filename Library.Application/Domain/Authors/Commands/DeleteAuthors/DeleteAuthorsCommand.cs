using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthors;

public record DeleteAuthorsCommand(
    Guid[] AuthorIds)
    : IRequest;
