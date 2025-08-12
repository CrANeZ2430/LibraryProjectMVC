using System.Diagnostics;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Home;

[Route("home")]
public class HomeController(ILogger<HomeController> logger) : Controller
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
