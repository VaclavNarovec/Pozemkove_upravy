using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PozemkoveUpravy.Data;
using PozemkoveUpravy.Interfaces;
using PozemkoveUpravy.Models;

namespace PozemkoveUpravy.Controllers
{
    public class PozemkovaUpravasController : Controller
    {
        private readonly PozemkoveUpravyContext _context;
        // private readonly IPozemkovaUpravaRepository _PozemkovaUpravaRepository;

        public PozemkovaUpravasController(PozemkoveUpravyContext context/*, IPozemkovaUpravaRepository PozemkovaUpravaRepository*/)
        {
            _context = context;
            // _PozemkovaUpravaRepository = PozemkovaUpravaRepository;
        }

        // GET: PozemkovaUpravas
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["KrajSortParm"] = String.IsNullOrEmpty(sortOrder) ? "kraj_desc" : "";
            ViewData["OkresSortParm"] = String.IsNullOrEmpty(sortOrder) ? "okres_desc" : "";
            ViewData["ObecSortParm"] = String.IsNullOrEmpty(sortOrder) ? "obec_desc" : "";
            ViewData["KatastralniUzemiSortParm"] = String.IsNullOrEmpty(sortOrder) ? "katastralniUzemi_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var pozemkoveUpravy = from s in _context.PozemkoveUpravy
                                  select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                pozemkoveUpravy = pozemkoveUpravy.Where(s => s.Kraj.Contains(searchString)
                                || s.Okres.Contains(searchString) || s.Obec.Contains(searchString) || s.Katastralni_uzemi.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "kraj_desc":
                    pozemkoveUpravy = pozemkoveUpravy.OrderByDescending(s => s.Kraj);
                    break;
                case "okres_desc":
                    pozemkoveUpravy = pozemkoveUpravy.OrderByDescending(s => s.Okres);
                    break;
                case "obec_desc":
                    pozemkoveUpravy = pozemkoveUpravy.OrderByDescending(s => s.Obec);
                    break;
                case "katastralniUzemi_desc":
                    pozemkoveUpravy = pozemkoveUpravy.OrderByDescending(s => s.Katastralni_uzemi);
                    break;
                default:
                    pozemkoveUpravy = pozemkoveUpravy.OrderBy(s => s.Id);
                    break;
            }

            int pageSize = 10;
            return View(await StrankyList<PozemkovaUprava>.CreateAsync(pozemkoveUpravy.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: PozemkovaUpravas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PozemkoveUpravy == null)
            {
                return NotFound();
            }

            var pozemkovaUprava = await _context.PozemkoveUpravy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozemkovaUprava == null)
            {
                return NotFound();
            }

            return View(pozemkovaUprava);
        }

        // GET: PozemkovaUpravas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PozemkovaUpravas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kraj,Okres,Obec,Katastralni_uzemi,Pozemkovy_urad,Forma_pozemkove_upravy,Pocatek,Konec")] 
                PozemkovaUprava pozemkovaUprava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozemkovaUprava);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pozemkovaUprava);
        }

        // GET: PozemkovaUpravas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PozemkoveUpravy == null)
            {
                return NotFound();
            }

            var pozemkovaUprava = await _context.PozemkoveUpravy.FindAsync(id);
            if (pozemkovaUprava == null)
            {
                return NotFound();
            }
            return View(pozemkovaUprava);
        }

        // POST: PozemkovaUpravas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kraj,Okres,Obec,Katastralni_uzemi,Pozemkovy_urad,Forma_pozemkove_upravy,Pocatek,Konec")] PozemkovaUprava pozemkovaUprava)
        {
            if (id != pozemkovaUprava.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozemkovaUprava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozemkovaUpravaExists(pozemkovaUprava.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pozemkovaUprava);
        }

        // GET: PozemkovaUpravas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PozemkoveUpravy == null)
            {
                return NotFound();
            }

            var pozemkovaUprava = await _context.PozemkoveUpravy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozemkovaUprava == null)
            {
                return NotFound();
            }

            return View(pozemkovaUprava);
        }

        // POST: PozemkovaUpravas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PozemkoveUpravy == null)
            {
                return Problem("Entity set 'PozemkoveUpravyContext.PozemkovaUprava'  is null.");
            }
            var pozemkovaUprava = await _context.PozemkoveUpravy.FindAsync(id);
            if (pozemkovaUprava != null)
            {
                _context.PozemkoveUpravy.Remove(pozemkovaUprava);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozemkovaUpravaExists(int id)
        {
          return (_context.PozemkoveUpravy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
