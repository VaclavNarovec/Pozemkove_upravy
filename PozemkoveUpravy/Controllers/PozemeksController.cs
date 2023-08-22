using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PozemkoveUpravy.Data;
using PozemkoveUpravy.Models;

namespace PozemkoveUpravy.Controllers
{
    public class PozemeksController : Controller
    {
        private readonly PozemkoveUpravyContext _context;

        public PozemeksController(PozemkoveUpravyContext context)
        {
            _context = context;
        }

        // GET: Pozemeks
        public async Task<IActionResult> Index()
        {
            var pozemkoveUpravyContext = _context.Pozemky.Include(p => p.Vlastnici);
            return View(await pozemkoveUpravyContext.ToListAsync());
        }

        // GET: Pozemeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pozemky == null)
            {
                return NotFound();
            }

            var pozemek = await _context.Pozemky
                .Include(p => p.Vlastnici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozemek == null)
            {
                return NotFound();
            }

            return View(pozemek);
        }

        // GET: Pozemeks/Create
        public IActionResult Create()
        {
            ViewData["VlastnikId"] = new SelectList(_context.Vlastnici, "Id", "Id");
            return View();
        }

        // POST: Pozemeks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VlastnikId,List_vlastnictvi,Cislo_pozemku,Druh_pozemku,Zpusob_vyuziti_nemovitosti,Zpusob_ochrany_nemovitosti,Vymera_v_m2,Vzdalenost_v_m")] Pozemek pozemek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozemek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VlastnikId"] = new SelectList(_context.Vlastnici, "Id", "Id", pozemek.VlastnikId);
            return View(pozemek);
        }

        // GET: Pozemeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pozemky == null)
            {
                return NotFound();
            }

            var pozemek = await _context.Pozemky.FindAsync(id);
            if (pozemek == null)
            {
                return NotFound();
            }
            ViewData["VlastnikId"] = new SelectList(_context.Vlastnici, "Id", "Id", pozemek.VlastnikId);
            return View(pozemek);
        }

        // POST: Pozemeks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VlastnikId,List_vlastnictvi,Cislo_pozemku,Druh_pozemku,Zpusob_vyuziti_nemovitosti,Zpusob_ochrany_nemovitosti,Vymera_v_m2,Vzdalenost_v_m")] Pozemek pozemek)
        {
            if (id != pozemek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozemek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozemekExists(pozemek.Id))
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
            ViewData["VlastnikId"] = new SelectList(_context.Vlastnici, "Id", "Id", pozemek.VlastnikId);
            return View(pozemek);
        }

        // GET: Pozemeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pozemky == null)
            {
                return NotFound();
            }

            var pozemek = await _context.Pozemky
                .Include(p => p.Vlastnici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozemek == null)
            {
                return NotFound();
            }

            return View(pozemek);
        }

        // POST: Pozemeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pozemky == null)
            {
                return Problem("Entity set 'PozemkoveUpravyContext.Pozemek'  is null.");
            }
            var pozemek = await _context.Pozemky.FindAsync(id);
            if (pozemek != null)
            {
                _context.Pozemky.Remove(pozemek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozemekExists(int id)
        {
          return (_context.Pozemky?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
