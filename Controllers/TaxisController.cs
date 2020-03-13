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
    public class TaxisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Taxis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Taxi.Include(t => t.Carro).Include(t => t.Chofer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Taxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxi
                .Include(t => t.Carro)
                .Include(t => t.Chofer)
                .FirstOrDefaultAsync(m => m.TaxiId == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // GET: Taxis/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carro, "Matricula", "Matricula");
            ViewData["ChoferId"] = new SelectList(_context.Chofer, "CI", "Direccion");
            return View();
        }

        // POST: Taxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxiId,ChoferId,CarroId,Deudas")] Taxi taxi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Matricula", "Matricula", taxi.CarroId);
            ViewData["ChoferId"] = new SelectList(_context.Chofer, "CI", "Direccion", taxi.ChoferId);
            return View(taxi);
        }

        // GET: Taxis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxi.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "Matricula", "Matricula", taxi.CarroId);
            ViewData["ChoferId"] = new SelectList(_context.Chofer, "CI", "Direccion", taxi.ChoferId);
            return View(taxi);
        }

        // POST: Taxis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxiId,ChoferId,CarroId,Deudas")] Taxi taxi)
        {
            if (id != taxi.TaxiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxiExists(taxi.TaxiId))
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
            ViewData["CarroId"] = new SelectList(_context.Carro, "Matricula", "Matricula", taxi.CarroId);
            ViewData["ChoferId"] = new SelectList(_context.Chofer, "CI", "Direccion", taxi.ChoferId);
            return View(taxi);
        }

        // GET: Taxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxi = await _context.Taxi
                .Include(t => t.Carro)
                .Include(t => t.Chofer)
                .FirstOrDefaultAsync(m => m.TaxiId == id);
            if (taxi == null)
            {
                return NotFound();
            }

            return View(taxi);
        }

        // POST: Taxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxi = await _context.Taxi.FindAsync(id);
            _context.Taxi.Remove(taxi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxiExists(int id)
        {
            return _context.Taxi.Any(e => e.TaxiId == id);
        }
    }
}
