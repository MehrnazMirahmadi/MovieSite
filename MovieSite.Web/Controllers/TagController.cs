using Microsoft.AspNetCore.Mvc;
using MovieSite.Application.Interfaces.TagInterfaces;
using MovieSite.Domain.Interfaces.TagInterfaces;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagServices _services;
        private readonly ITagRepository _tagRepository;
        public TagController(ITagServices services,ITagRepository tagRepository)
        {
            _services = services;
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index(FilterTagViewModel filterTag)
        {
            var result =await _services.GetFilterTag(filterTag);
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _tagRepository.GetByIdAsync(id);
            if (result == null) {
                return NotFound();
            }
            return View(result);
        }

    }
}
