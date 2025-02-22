using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.Search;

namespace MovieSite.Domain.ViewModels.FilmTagsViewModels
{
    public class FilterTagsViewModel: SearchItems<FilmTag>
    {
        public string FilterFilmTitle { get; set; }
        public string FilterTag { get; set; }
    }
}
