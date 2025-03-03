using Microsoft.EntityFrameworkCore;
using MovieSite.Data.Context;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.TagInterfaces;
using MovieSite.Domain.ViewModels.FilmTagsViewModels;
using MovieSite.Domain.ViewModels.FilmViewModels;
using MovieSite.Domain.ViewModels.Paging;
using MovieSite.Domain.ViewModels.TagsViewModel;

namespace MovieSite.Data.Repository.FilmTagRepository
{
    public class TagRepository : IRepository<Tag>, ITagRepository
    {
        private readonly MovieDbContext _context;
        public TagRepository(MovieDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Tag entity)
        {
            await _context.Tags.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Tags.FindAsync(id);
            if (entity != null)
            {
                _context.Tags.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FilterTagViewModel> FilterTag(FilterTagViewModel filterTag)
        {
            var query = _context.Tags.AsQueryable();

        

            if (!string.IsNullOrEmpty(filterTag.FilterTag))
            {
                query = query.Where(t => EF.Functions.Like(t.TagText, $"%{filterTag.FilterTag}%"));
            }

            var totalCount = await query.CountAsync();
            var pager = Pager.Build(filterTag.PageId, totalCount, filterTag.TakeEntity, filterTag.HowManyShowPageAfterAndBefore);

            var pagedFilms = await query
                .Skip((filterTag.PageId - 1) * filterTag.TakeEntity)
                .Take(filterTag.TakeEntity)
                .ToListAsync();

            return filterTag.SetEntity(pagedFilms).SetPaging(pager) as FilterTagViewModel;
        }

       
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task UpdateAsync(Tag entity)
        {
            _context.Tags.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
