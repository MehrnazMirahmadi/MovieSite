using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.FilmTagsViewModels;

namespace MovieSite.Domain.Interfaces.TagInterfaces
{
    public interface ITagRepository : IRepository<FilmTag>
    {
        Task<FilterTagsViewModel> FilterFilmTag(FilterTagsViewModel filmTag);
    }
}
