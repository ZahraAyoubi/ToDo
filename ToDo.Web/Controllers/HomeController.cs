using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDo.Web.Models;

namespace ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string actionName)
        {
            ViewBag.ErrorMessage = "User can not "+ actionName + " the ToDo.";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Login()
        {
            var accessToken = HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}