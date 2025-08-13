using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.DeleteAuthors;

public class DeleteAuthorsCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteAuthorsCommand>
{
    public async Task Handle(DeleteAuthorsCommand command, CancellationToken cancellationToken = default)
    {
        var authors = await authorsRepository.GetByIds(command.AuthorIds);

        foreach (var author in authors)
            authorsRepository.Remove(author);

        await unitOfWork.SaveChangesAsync();
    }
}
