using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdministarRenta.Data;
using AdministarRenta.Models;

namespace AdministarRenta.Controllers
{
    public class ItinerariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItinerariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Itinerarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Itinerario.Include(i => i.Huesped);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Itinerarios/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itinerario = await _context.Itinerario
                .Include(i => i.Huesped)
                .FirstOrDefaultAsync(m => m.FechaRecogida == id);
            if (itinerario == null)
            {
                return NotFound();
            }

            return View(itinerario);
        }

        // GET: Itinerarios/Create
        public IActionResult Create()
        {
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre");
            return View();
        }

        // POST: Itinerarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HuespedId,FechaRecogida,CantidasDeDias,Jefe,Recorrido,Resumen")] Itinerario itinerario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itinerario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", itinerario.HuespedId);
            return View(itinerario);
        }

        // GET: Itinerarios/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itinerario = await _context.Itinerario.FindAsync(id);
            if (itinerario == null)
            {
                return NotFound();
            }
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", itinerario.HuespedId);
            return View(itinerario);
        }

        // POST: Itinerarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("HuespedId,FechaRecogida,CantidasDeDias,Jefe,Recorrido,Resumen")] Itinerario itinerario)
        {
            if (id != itinerario.FechaRecogida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itinerario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItinerarioExists(itinerario.FechaRecogida))
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
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", itinerario.HuespedId);
            return View(itinerario);
        }

        // GET: Itinerarios/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itinerario = await _context.Itinerario
                .Include(i => i.Huesped)
                .FirstOrDefaultAsync(m => m.FechaRecogida == id);
            if (itinerario == null)
            {
                return NotFound();
            }

            return View(itinerario);
        }

        // POST: Itinerarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var itinerario = await _context.Itinerario.FindAsync(id);
            _context.Itinerario.Remove(itinerario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItinerarioExists(DateTime id)
        {
            return _context.Itinerario.Any(e => e.FechaRecogida == id);
        }
    }
}
