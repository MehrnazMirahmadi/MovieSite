using Microsoft.EntityFrameworkCore;
using MovieSite.Data.Context;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.TagInterfaces;
using MovieSite.Domain.ViewModels.FilmTagsViewModels;
using MovieSite.Domain.ViewModels.FilmViewModels;
using MovieSite.Domain.ViewModels.Paging;

namespace MovieSite.Data.Repository.FilmTagRepository
{
    public class TagRepository : IRepository<FilmTag>, ITagRepository
    {
        private readonly MovieDbContext _context;
        public TagRepository(MovieDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(FilmTag entity)
        {
            await _context.FilmTags.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.FilmTags.FindAsync(id);
            if (entity != null)
            {
                _context.FilmTags.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FilterTagsViewModel> FilterFilmTag(FilterTagsViewModel filmTag)
        {
            var query = _context.FilmTags
                                .Include(t => t.Film)
                                .Include(t => t.Tag)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(filmTag.FilterFilmTitle))
            {
                query = query.Where(t => EF.Functions.Like(t.Film.FilmTitle, $"%{filmTag.FilterFilmTitle}%"));
            }

            if (!string.IsNullOrEmpty(filmTag.FilterTag))
            {
                query = query.Where(t => EF.Functions.Like(t.Tag.TagText, $"%{filmTag.FilterTag}%"));
            }

            var totalCount = await query.CountAsync();
            var pager = Pager.Build(filmTag.PageId, totalCount, filmTag.TakeEntity, filmTag.HowManyShowPageAfterAndBefore);

            var pagedFilms = await query
                .Skip((filmTag.PageId - 1) * filmTag.TakeEntity)
                .Take(filmTag.TakeEntity)
                .ToListAsync();

            return filmTag.SetEntity(pagedFilms).SetPaging(pager) as FilterTagsViewModel;
        }


        public async Task<IEnumerable<FilmTag>> GetAllAsync()
        {
            return await _context.FilmTags.ToListAsync();
        }

        public async Task<FilmTag> GetByIdAsync(int id)
        {
            return await _context.FilmTags.FindAsync(id);
        }

        public async Task UpdateAsync(FilmTag entity)
        {
            _context.FilmTags.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
