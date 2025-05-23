﻿using Microsoft.AspNetCore.Mvc;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces.FilmInterfaces;
using MovieSite.Domain.ViewModels.FilmViewModels;

namespace MovieSite.Web.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IFilmServices _filmServices;

        public FilmController(IFilmServices filmServices,IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
            _filmServices = filmServices;
        }

        // GET: Film
        public async Task<IActionResult> Index(FilterFilmViewModel filter)
        {
            var filteredFilms = await _filmServices.GetFilterFilm(filter);
            return View(filteredFilms);
        }


        public async Task<IActionResult> Details(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
                await _filmRepository.AddAsync(film);
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var film = await _filmRepository.GetByIdAsync(id);
        //    if (film == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(film);
        //}
        [HttpGet]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return Json(film);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Film film)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(film.FilmID);
            if (existingFilm == null)
            {
                return NotFound();
            }

            existingFilm.FilmTitle = film.FilmTitle;
            existingFilm.Minute = film.Minute;
            existingFilm.CoverImage = film.CoverImage;

            await _filmRepository.UpdateAsync(existingFilm);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await _filmRepository.GetByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            await _filmRepository.DeleteAsync(id);
            return Ok();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Film film)
        //{
        //    if (id != film.FilmID)
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
