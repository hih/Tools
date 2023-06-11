using Microsoft.AspNetCore.Mvc;

namespace Tools.Controllers
{
    [Route("Error/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            ViewData["Title"] = statusCode;
            return View();
        }
    }
}
