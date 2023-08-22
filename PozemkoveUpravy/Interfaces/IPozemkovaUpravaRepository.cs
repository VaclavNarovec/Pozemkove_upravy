using PozemkoveUpravy.Models;

namespace PozemkoveUpravy.Interfaces
{
    public interface IPozemkovaUpravaRepository
    {
        Task<IEnumerable<PozemkovaUprava>> GetAll();
        Task<PozemkovaUprava> GetByIdAsync(int id);
        bool Add(PozemkovaUprava pozemkovaUprava);
        bool Update(PozemkovaUprava pozemkovaUprava);
        bool Delete(PozemkovaUprava pozemkovaUprava);
        bool Save();
    }
}
