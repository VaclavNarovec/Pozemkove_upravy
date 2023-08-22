using Microsoft.EntityFrameworkCore;
using PozemkoveUpravy.Data;
using PozemkoveUpravy.Interfaces;
using PozemkoveUpravy.Models;

namespace PozemkoveUpravy.Repository
{
    public class PozemkovaUpravaRepository : IPozemkovaUpravaRepository
    {
        private readonly PozemkoveUpravyContext _context;

        public PozemkovaUpravaRepository(PozemkoveUpravyContext context)
        {
            _context = context;
        }

        public bool Add(PozemkovaUprava pozemkovaUprava)
        {
            _context.Add(pozemkovaUprava);
            return Save();
        }

        public bool Delete(PozemkovaUprava pozemkovaUprava)
        {
            _context.Remove(pozemkovaUprava);
            return Save();
        }

        public async Task<IEnumerable<PozemkovaUprava>> GetAll()
        {
            return await _context.PozemkoveUpravy.ToListAsync();
        }

        public async Task<PozemkovaUprava> GetByIdAsync(int id)
        {
            return await _context.PozemkoveUpravy.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(PozemkovaUprava pozemkovaUprava)
        {
            throw new NotImplementedException();
        }
    }
}
