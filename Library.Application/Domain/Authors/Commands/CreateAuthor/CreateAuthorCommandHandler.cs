using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Data;
using Library.Core.Domain.Authors.Models;
using MediatR;

namespace Library.Application.Domain.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler(
    IAuthorsRepository authorsRepository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateAuthorCommand, Guid>
{
    public async Task<Guid> Handle(CreateAuthorCommand command, CancellationToken cancellationToken = default)
    {
        var authorData = new CreateAuthorData(
            command.FirstName,
            command.LastName,
            command.MiddleName,
            command.Biography,
            command.ImageUrl);

        var author = Author.Create(authorData);

        await authorsRepository.AddAsync(author, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return author.Id;
    }
}
