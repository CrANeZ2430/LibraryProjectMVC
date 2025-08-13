using Library.API.ViewModels.Authors.AuthorDetailsPage;
using Library.API.ViewModels.Authors.AuthorsPage;
using Library.Application.Domain.Authors.Commands.CreateAuthor;
using Library.Application.Domain.Authors.Commands.DeleteAuthors;
using Library.Application.Domain.Authors.Queries.GetAuthorById;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Authors
{
    [Route("authors")]
    public class AuthorsController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAuthors(
            int page = 1,
            int authorPerPage = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAuthorsQuery(page, authorPerPage);
            var result = await mediator.Send(query, cancellationToken);

            var authors = result.Data
                .Select(a => new AuthorViewModel(
                a.Id,
                a.FirstName,
                a.LastName,
                a.MiddleName,
                a.Biography,
                a.ImageUrl));

            var pageModel = new AuthorsPageViewModel(
                authors,
                null,
                page,
                page < (result.TotalCount / authorPerPage + (result.TotalCount % authorPerPage > 0 ? 1 : 0)));

            return View(pageModel);
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorDetails(
            Guid authorId, 
            CancellationToken cancellationToken = default)
        {
            var query = new GetAuthorByIdQuery(authorId);
            var result = await mediator.Send(query, cancellationToken);

            var author = new AuthorDetailsViewModel(
                result.FirstName,
                result.LastName,
                result.MiddleName,
                result.Biography,
                result.ImageUrl);

            return View(author);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAuthor(
            AuthorsPageViewModel model,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateAuthorCommand(
                model.AddAuthor.FirstName,
                model.AddAuthor.LastName,
                model.AddAuthor.MiddleName,
                model.AddAuthor.Biography,
                model.AddAuthor.ImageUrl);
            var result = await mediator.Send(command, cancellationToken);

            return RedirectToAction("GetAuthors", "Authors");
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAuthors(
            Guid[] SelectedAuthorIds, 
            CancellationToken cancellationToken = default)
        {
            var command = new DeleteAuthorsCommand(SelectedAuthorIds);
            await mediator.Send(command);

            return RedirectToAction("GetAuthors", "Authors");
        }
    }
}
