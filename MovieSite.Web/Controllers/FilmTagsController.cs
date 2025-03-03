using Microsoft.AspNetCore.Mvc;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Web.Controllers
{
    public class FilmTagsController : Controller
    {
        private readonly IFilmServices  _filmServices;
        public async Task<IActionResult> Index(FilterTagViewModel filterTags)
        {
            
            return View();
        }
    }
}
