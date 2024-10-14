using Microsoft.EntityFrameworkCore;
using MovieSite.Data.Context;
using MovieSite.Domain.Interfaces;
using MovieSite.Domain.Interfaces.BoxInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSite.Data.Repository.Box
{
    public class BoxRepository : IBoxRepository
    {
        private readonly MovieDbContext _context;

        public BoxRepository(MovieDbContext context)
        {
            _context = context;
        }

    
        public async Task DeleteAsync(int id)
        {
            var box = await _context.Boxes.FindAsync(id);
            if (box != null)
            {
                _context.Boxes.Remove(box);
                await _context.SaveChangesAsync();
            }
        }

       async Task<IEnumerable<Domain.Entities.Box>> IRepository<Domain.Entities.Box>.GetAllAsync()
        {
            return await _context.Boxes.ToListAsync();
        }

       async Task<Domain.Entities.Box> IRepository<Domain.Entities.Box>.GetByIdAsync(int id)
        {
            return await _context.Boxes.FindAsync(id); 
        }

        public async Task AddAsync(Domain.Entities.Box entity)
        {
            _context.Boxes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Box entity)
        {
            _context.Boxes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
