using Microsoft.AspNetCore.Mvc; // Importing the necessary namespace for MVC
using System.Diagnostics; // Importing the System.Diagnostics namespace for activity tracking
using testLayout.Models; // Importing the namespace for the ErrorViewModel

namespace TuinenIdesWebCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger instance for logging

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // Injecting the logger instance through constructor
        }

        public IActionResult Index() // Action method for the "Index" page
        {
            return View(); // Returning a view for the "Index" page
        }

        public IActionResult Privacy() // Action method for the "Privacy" page
        {
            return View(); // Returning a view for the "Privacy" page
        }

        public IActionResult CookiePolicy() // Action method for the "CookiePolicy" page
        {
            return View(); // Returning a view for the "CookiePolicy" page
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // Applying response caching attributes to the "Error" action
        public IActionResult Error() // Action method for the "Error" page
        {
            // Creating an ErrorViewModel instance to pass to the view
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
