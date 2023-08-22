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
    public class OceneniPozemkusController : Controller
    {
        private readonly PozemkoveUpravyContext _context;

        public OceneniPozemkusController(PozemkoveUpravyContext context)
        {
            _context = context;
        }

        // GET: OceneniPozemkus
        public async Task<IActionResult> Index()
        {
            var pozemkoveUpravyContext = _context.OceneniPozemkuA.Include(o => o.Pozemky);
            return View(await pozemkoveUpravyContext.ToListAsync());
        }

        // GET: OceneniPozemkus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OceneniPozemkuA == null)
            {
                return NotFound();
            }

            var oceneniPozemku = await _context.OceneniPozemkuA
                .Include(o => o.Pozemky)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oceneniPozemku == null)
            {
                return NotFound();
            }

            return View(oceneniPozemku);
        }

        // GET: OceneniPozemkus/Create
        public IActionResult Create()
        {
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id");
            return View();
        }

        // POST: OceneniPozemkus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PozemekId,VlastnikId,BPEJ,Vymera_v_m2,Cena_v_Kc")] OceneniPozemku oceneniPozemku)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oceneniPozemku);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id", oceneniPozemku.PozemekId);
            return View(oceneniPozemku);
        }

        // GET: OceneniPozemkus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OceneniPozemkuA == null)
            {
                return NotFound();
            }

            var oceneniPozemku = await _context.OceneniPozemkuA.FindAsync(id);
            if (oceneniPozemku == null)
            {
                return NotFound();
            }
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id", oceneniPozemku.PozemekId);
            return View(oceneniPozemku);
        }

        // POST: OceneniPozemkus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PozemekId,VlastnikId,BPEJ,Vymera_v_m2,Cena_v_Kc")] OceneniPozemku oceneniPozemku)
        {
            if (id != oceneniPozemku.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oceneniPozemku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OceneniPozemkuExists(oceneniPozemku.Id))
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
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id", oceneniPozemku.PozemekId);
            return View(oceneniPozemku);
        }

        // GET: OceneniPozemkus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OceneniPozemkuA == null)
            {
                return NotFound();
            }

            var oceneniPozemku = await _context.OceneniPozemkuA
                .Include(o => o.Pozemky)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oceneniPozemku == null)
            {
                return NotFound();
            }

            return View(oceneniPozemku);
        }

        // POST: OceneniPozemkus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OceneniPozemkuA == null)
            {
                return Problem("Entity set 'PozemkoveUpravyContext.OceneniPozemku'  is null.");
            }
            var oceneniPozemku = await _context.OceneniPozemkuA.FindAsync(id);
            if (oceneniPozemku != null)
            {
                _context.OceneniPozemkuA.Remove(oceneniPozemku);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OceneniPozemkuExists(int id)
        {
          return (_context.OceneniPozemkuA?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
