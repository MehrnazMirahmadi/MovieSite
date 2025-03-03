using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.FilmTagsViewModels;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Domain.Interfaces.TagInterfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<FilterTagViewModel> FilterTag(FilterTagViewModel filterTag);
        
    }
}
