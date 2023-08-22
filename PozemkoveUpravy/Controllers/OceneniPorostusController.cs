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
    public class OceneniPorostusController : Controller
    {
        private readonly PozemkoveUpravyContext _context;

        public OceneniPorostusController(PozemkoveUpravyContext context)
        {
            _context = context;
        }

        // GET: OceneniPorostus
        public async Task<IActionResult> Index()
        {
            var pozemkoveUpravyContext = _context.OceneniPorostuA.Include(o => o.Pozemky);
            return View(await pozemkoveUpravyContext.ToListAsync());
        }

        // GET: OceneniPorostus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OceneniPorostuA == null)
            {
                return NotFound();
            }

            var oceneniPorostu = await _context.OceneniPorostuA
                .Include(o => o.Pozemky)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oceneniPorostu == null)
            {
                return NotFound();
            }

            return View(oceneniPorostu);
        }

        // GET: OceneniPorostus/Create
        public IActionResult Create()
        {
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id");
            return View();
        }

        // POST: OceneniPorostus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PozemekId,VlastnikId,Druh_porostu,Vymera_v_m2,Cena_v_Kc")] OceneniPorostu oceneniPorostu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oceneniPorostu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id", oceneniPorostu.PozemekId);
            return View(oceneniPorostu);
        }

        // GET: OceneniPorostus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OceneniPorostuA == null)
            {
                return NotFound();
            }

            var oceneniPorostu = await _context.OceneniPorostuA.FindAsync(id);
            if (oceneniPorostu == null)
            {
                return NotFound();
            }
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id", oceneniPorostu.PozemekId);
            return View(oceneniPorostu);
        }

        // POST: OceneniPorostus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PozemekId,VlastnikId,Druh_porostu,Vymera_v_m2,Cena_v_Kc")] OceneniPorostu oceneniPorostu)
        {
            if (id != oceneniPorostu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oceneniPorostu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OceneniPorostuExists(oceneniPorostu.Id))
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
            ViewData["PozemekId"] = new SelectList(_context.Pozemky, "Id", "Id", oceneniPorostu.PozemekId);
            return View(oceneniPorostu);
        }

        // GET: OceneniPorostus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OceneniPorostuA == null)
            {
                return NotFound();
            }

            var oceneniPorostu = await _context.OceneniPorostuA
                .Include(o => o.Pozemky)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oceneniPorostu == null)
            {
                return NotFound();
            }

            return View(oceneniPorostu);
        }

        // POST: OceneniPorostus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OceneniPorostuA == null)
            {
                return Problem("Entity set 'PozemkoveUpravyContext.OceneniPorostu'  is null.");
            }
            var oceneniPorostu = await _context.OceneniPorostuA.FindAsync(id);
            if (oceneniPorostu != null)
            {
                _context.OceneniPorostuA.Remove(oceneniPorostu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OceneniPorostuExists(int id)
        {
          return (_context.OceneniPorostuA?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
