using Microsoft.EntityFrameworkCore;
using MovieSite.Data.Context;
using MovieSite.Domain.Entities;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.FilmInterfaces;
using MovieSite.Domain.ViewModels.FilmViewModels;
using MovieSite.Domain.ViewModels.Paging;

namespace MovieSite.Data.Repository.FilmRepository
{
    public class FilmRepository : IRepository<Film>, IFilmRepository
    {
        private readonly MovieDbContext _context;

        public FilmRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Film entity)
        {
            await _context.Films.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<FilterFilmViewModel> FilterFilm(FilterFilmViewModel filter)
        {
            var query = _context.Films.AsQueryable();

            #region Filter
            if (!string.IsNullOrWhiteSpace(filter.FilterTitle))
            {
                query = query.Where(f => f.FilmTitle.Contains(filter.FilterTitle));
            }

            if (filter.FilterRegDateFrom.HasValue)
            {
                query = query.Where(f => f.RegDate >= filter.FilterRegDateFrom.Value);
            }

            if (filter.FilterRegDateTo.HasValue)
            {
                query = query.Where(f => f.RegDate <= filter.FilterRegDateTo.Value);
            }
            #endregion

            #region Paging
            var totalCount = await query.CountAsync();
            var pager = Pager.Build(filter.PageId, totalCount, filter.TakeEntity, filter.HowManyShowPageAfterAndBefore);

            var pagedFilms = await query
                .Paging(pager)
                .ToListAsync();
            #endregion
            return filter.SetEntity(pagedFilms).SetPaging(pager) as FilterFilmViewModel;
        }


        public async Task<IEnumerable<Film>> GetAllAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film> GetByIdAsync(int id)
        {
            return await _context.Films.FindAsync(id);
        }

        public async Task UpdateAsync(Film entity)
        {
            _context.Films.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
