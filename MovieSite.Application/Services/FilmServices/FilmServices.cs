using Microsoft.EntityFrameworkCore;
using MovieSite.Application.Interfaces.FilmInterfaces;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.FilmInterfaces;
using MovieSite.Domain.ViewModels.FilmViewModels;
using MovieSite.Domain.ViewModels.Paging;
using MovieSite.Domain.ViewModels.Search;

namespace MovieSite.Application.Services.FilmServices
{
    public class FilmServices : IFilmServices
    {
        private readonly IRepository<Film> _repository; 
        private readonly IFilmRepository _filmRepository;

        public FilmServices(IRepository<Film> repository, IFilmRepository filmRepository)
        {
            _repository = repository;
            _filmRepository = filmRepository;
        }

        public async Task<FilterFilmViewModel> GetFilterFilm(FilterFilmViewModel filter)
        {
            return await _filmRepository.FilterFilm(filter); 
        }
    }

}
