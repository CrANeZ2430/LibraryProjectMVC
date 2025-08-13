using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthors;

public class DeleteAuthorsCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAuthorsCommand>
{
    public async Task Handle(DeleteAuthorsCommand command, CancellationToken cancellationToken = default)
    {
        var authors = await Task.WhenAll(command.AuthorIds.Select(id =>
            authorsRepository.GetById(id, cancellationToken)));

        foreach (var author in authors)
            authorsRepository.Remove(author);

        await unitOfWork.SaveChangesAsync();
    }
}
