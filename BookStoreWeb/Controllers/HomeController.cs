using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.BagMessage = "Hello I am from ViewBag, Hi!";

            ViewData["DataStore"] = "I came from ViewData, Hola!";

            TempData["TempKey"] = "Hi from TempData, Mingalarpar!";
            return View();
        }

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
}
