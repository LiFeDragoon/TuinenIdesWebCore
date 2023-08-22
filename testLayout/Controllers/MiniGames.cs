using Microsoft.AspNetCore.Mvc; // Importing the necessary namespace for MVC

namespace TuinenIdesWebCore.Controllers
{
    public class MiniGames : Controller
    {
        // This controller handles requests related to mini games

        // GET: /MiniGames/Index
        // Handles GET requests for the "Index" action within the MiniGames controller
        public IActionResult Index()
        {
            // Render the Index view associated with the "Index" action
            return View();
        }
    }
}
