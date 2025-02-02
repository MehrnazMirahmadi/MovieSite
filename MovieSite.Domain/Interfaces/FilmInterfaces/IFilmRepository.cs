using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.FilmViewModels;

namespace MovieSite.Domain.Interfaces.FilmInterfaces
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<FilterFilmViewModel> FilterFilm(FilterFilmViewModel filter);
    }
}
