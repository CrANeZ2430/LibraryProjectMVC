using Library.API.ViewModels.Authors;
using Library.Application.Domain.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Author
{
    [Route("authors")]
    public class AuthorsController(IMediator mediator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAuthors(CancellationToken cancellationToken = default)
        {
            var query = new GetAuthorsQuery(1, 10);
            var result = await mediator.Send(query, cancellationToken);
            var authors = result.Data
                .Select(a => new AuthorViewModel(
                a.Id,
                a.FirstName,
                a.LastName,
                a.MiddleName,
                a.Biography,
                a.ImageUrl));

            return View(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorDetails(Guid id)
        {
            return View();
        }
    }
}
