using Microsoft.AspNetCore.Mvc;

namespace MovieSite.Web.Controllers
{
    public class FilmTagsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
