using Microsoft.AspNetCore.Mvc;
using MovieSite.Application.Interfaces.TagInterfaces;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagServices _services;

        public TagController(ITagServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index(FilterTagViewModel filterTag)
        {
            var result =await _services.GetFilterTag(filterTag);
            return View(result);
        }
    }
}
