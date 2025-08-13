using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Books
{
    public class BooksController : Controller
    {
        public IActionResult GetBooks()
        {
            return View();
        }
    }
}
