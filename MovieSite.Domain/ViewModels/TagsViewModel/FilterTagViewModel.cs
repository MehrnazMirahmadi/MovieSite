using MovieSite.Domain.Entities;
using MovieSite.Domain.ViewModels.Search;

namespace MovieSite.Domain.ViewModels.TagsViewModel
{
    public class FilterTagViewModel : SearchItems<Tag>
    {
        public string FilterTag { get; set; }
    }
}
