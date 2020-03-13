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
    public class AlquiladosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlquiladosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alquilados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alquilado.Include(a => a.Huésped).Include(a => a.casa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alquilados/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilado = await _context.Alquilado
                .Include(a => a.Huésped)
                .Include(a => a.casa)
                .FirstOrDefaultAsync(m => m.FechaEntrada == id);
            if (alquilado == null)
            {
                return NotFound();
            }

            return View(alquilado);
        }

        // GET: Alquilados/Create
        public IActionResult Create()
        {
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre");
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "Ubicacion");
            return View();
        }

        // POST: Alquilados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaEntrada,HuespedId,CasaId,ReservacionDias,Valores")] Alquilado alquilado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquilado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", alquilado.HuespedId);
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "Ubicacion", alquilado.CasaId);
            return View(alquilado);
        }

        // GET: Alquilados/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilado = await _context.Alquilado.FindAsync(id);
            if (alquilado == null)
            {
                return NotFound();
            }
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", alquilado.HuespedId);
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "Ubicacion", alquilado.CasaId);
            return View(alquilado);
        }

        // POST: Alquilados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("FechaEntrada,HuespedId,CasaId,ReservacionDias,Valores")] Alquilado alquilado)
        {
            if (id != alquilado.FechaEntrada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquilado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquiladoExists(alquilado.FechaEntrada))
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
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", alquilado.HuespedId);
            ViewData["CasaId"] = new SelectList(_context.Casa, "CasaId", "Ubicacion", alquilado.CasaId);
            return View(alquilado);
        }

        // GET: Alquilados/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquilado = await _context.Alquilado
                .Include(a => a.Huésped)
                .Include(a => a.casa)
                .FirstOrDefaultAsync(m => m.FechaEntrada == id);
            if (alquilado == null)
            {
                return NotFound();
            }

            return View(alquilado);
        }

        // POST: Alquilados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var alquilado = await _context.Alquilado.FindAsync(id);
            _context.Alquilado.Remove(alquilado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquiladoExists(DateTime id)
        {
            return _context.Alquilado.Any(e => e.FechaEntrada == id);
        }
    }
}
