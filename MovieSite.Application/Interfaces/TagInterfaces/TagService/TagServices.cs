using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.TagInterfaces;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Application.Interfaces.TagInterfaces.TagService;

public class TagServices : ITagServices
{
    private readonly ITagRepository _tagRepository;
    private readonly IRepository<Film> _repository;

    public TagServices(ITagRepository tagRepository, IRepository<Film> repository)
    {
        _tagRepository = tagRepository;
        _repository = repository;
    }

    public async Task<FilterTagViewModel> GetFilterTag(FilterTagViewModel filterTagViewModel)
    {
        return await _tagRepository.FilterTag(filterTagViewModel);
    }
}
