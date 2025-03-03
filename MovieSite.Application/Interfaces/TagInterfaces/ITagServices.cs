using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Application.Interfaces.TagInterfaces;

public interface ITagServices
{
    Task<FilterTagViewModel> GetFilterTag(FilterTagViewModel filterTagViewModel);
}
