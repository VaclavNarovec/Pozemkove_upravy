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
    public class VlastniksController : Controller
    {
        private readonly PozemkoveUpravyContext _context;

        public VlastniksController(PozemkoveUpravyContext context)
        {
            _context = context;
        }

        // GET: Vlastniks
        public async Task<IActionResult> Index()
        {
            var pozemkoveUpravyContext = _context.Vlastnici
                .Include(v => v.PozemkoveUpravy);
            return View(await pozemkoveUpravyContext.ToListAsync());
        }

        // GET: Vlastniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vlastnici == null)
            {
                return NotFound();
            }

            var vlastnik = await _context.Vlastnici
                .Include(v => v.PozemkoveUpravy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlastnik == null)
            {
                return NotFound();
            }

            return View(vlastnik);
        }

        // GET: Vlastniks/Create
        public IActionResult Create()
        {
            ViewBag.PozemkovaUpravaId = new SelectList(_context.PozemkoveUpravy, "Id", "Katastralni_uzemi");
            return View();
        }

        // POST: Vlastniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PozemkovaUpravaId,Jmeno,Prijmeni,Email,Telefon,Obec,Ulice,Cislo_popisne,PSC,List_vlastnictvi")] Vlastnik vlastnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlastnik);
                await _context.SaveChangesAsync();
                ViewBag.PozemkovaUpravaId = new SelectList(_context.PozemkoveUpravy, "Id", "Katastralni_uzemi", vlastnik.PozemkovaUpravaId);
                return RedirectToAction("Index");
            }
            return View(vlastnik);
        }

        // GET: Vlastniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vlastnici == null)
            {
                return NotFound();
            }

            var vlastnik = await _context.Vlastnici.FindAsync(id);
            if (vlastnik == null)
            {
                return NotFound();
            }
            ViewData["PozemkovaUpravaId"] = new SelectList(_context.PozemkoveUpravy, "Id", "PozemkovaUpravaId", vlastnik.PozemkovaUpravaId);
            return View(vlastnik);
        }

        // POST: Vlastniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PozemkovaUpravaId,Jmeno,Prijmeni,Email,Telefon,Obec,Ulice,Cislo_popisne,PSC,List_vlastnictvi")] Vlastnik vlastnik)
        {
            if (id != vlastnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vlastnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VlastnikExists(vlastnik.Id))
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
            ViewData["PozemkovaUpravaId"] = new SelectList(_context.PozemkoveUpravy, "Id", "PozemkovaUpravaId", vlastnik.PozemkovaUpravaId);
            return View(vlastnik);
        }

        // GET: Vlastniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vlastnici == null)
            {
                return NotFound();
            }

            var vlastnik = await _context.Vlastnici
                .Include(v => v.PozemkoveUpravy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlastnik == null)
            {
                return NotFound();
            }

            return View(vlastnik);
        }

        // POST: Vlastniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vlastnici == null)
            {
                return Problem("Entity set 'PozemkoveUpravyContext.Vlastnik'  is null.");
            }
            var vlastnik = await _context.Vlastnici.FindAsync(id);
            if (vlastnik != null)
            {
                _context.Vlastnici.Remove(vlastnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VlastnikExists(int id)
        {
          return (_context.Vlastnici?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
