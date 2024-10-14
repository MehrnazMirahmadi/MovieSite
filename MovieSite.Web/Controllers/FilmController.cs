using Microsoft.AspNetCore.Mvc;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces.FilmInterfaces;
using MovieSite.Domain.ViewModels.FilmViewModels;

namespace MovieSite.Web.Controllers
{
    public class FilmController : Controller
    {
       // private readonly IFilmRepository _filmRepository;
        private readonly IFilmServices _filmServices;

        public FilmController(IFilmServices filmServices)
        {
         //   _filmRepository = filmRepository;
            _filmServices = filmServices;
        }

        // GET: Film
        public async Task<IActionResult> Index(FilterFilmViewModel filter)
        {
            //var filteredFilms = await _filmServices.GetFilterFilm(filter);
            return View();
        }

 
        //public async Task<IActionResult> Details(int id)
        //{
        //    var film = await _filmRepository.GetByIdAsync(id);
        //    if (film == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(film);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

   
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Film film)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _filmRepository.AddAsync(film);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(film);
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var film = await _filmRepository.GetByIdAsync(id);
        //    if (film == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(film);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Film film)
        //{
        //    if (id != film.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        await _filmRepository.UpdateAsync(film);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(film);
        //}

     
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var film = await _filmRepository.GetByIdAsync(id);
    //        if (film == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(film);
    //    }
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        await _filmRepository.DeleteAsync(id);
    //        return RedirectToAction(nameof(Index));
    //    }
    }
}
