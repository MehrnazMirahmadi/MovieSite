using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.FilmViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Domain.Interfaces.FilmInterfaces
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<FilterFilmViewModel> FilterFilm(FilterFilmViewModel filter);
    }
}
