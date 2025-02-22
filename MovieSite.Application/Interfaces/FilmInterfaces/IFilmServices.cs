using MovieSite.Domain.ViewModels.FilmViewModels;

namespace MovieSite.Application.Interfaces.FilmInterfaces
{
    public interface IFilmServices 
    {
     Task<FilterFilmViewModel> GetFilterFilm(FilterFilmViewModel filter);
     Task<FilterFilmViewModel> GetSpecialFilm(FilterFilmViewModel filter);
    }
}
