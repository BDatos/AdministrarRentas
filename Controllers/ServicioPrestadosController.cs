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
    public class ServicioPrestadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioPrestadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicioPrestados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServicioPrestado.Include(s => s.Huésped).Include(s => s.Servicios);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServicioPrestados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioPrestado = await _context.ServicioPrestado
                .Include(s => s.Huésped)
                .Include(s => s.Servicios)
                .FirstOrDefaultAsync(m => m.ServiciosPrestadoId == id);
            if (servicioPrestado == null)
            {
                return NotFound();
            }

            return View(servicioPrestado);
        }

        // GET: ServicioPrestados/Create
        public IActionResult Create()
        {
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre");
            ViewData["ServiciosId"] = new SelectList(_context.Set<Servicios>(), "ServicioID", "Tipo");
            return View();
        }

        // POST: ServicioPrestados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiciosPrestadoId,HuespedId,ServiciosId,Resumen")] ServicioPrestado servicioPrestado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioPrestado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", servicioPrestado.HuespedId);
            ViewData["ServiciosId"] = new SelectList(_context.Set<Servicios>(), "ServicioID", "Tipo", servicioPrestado.ServiciosId);
            return View(servicioPrestado);
        }

        // GET: ServicioPrestados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioPrestado = await _context.ServicioPrestado.FindAsync(id);
            if (servicioPrestado == null)
            {
                return NotFound();
            }
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", servicioPrestado.HuespedId);
            ViewData["ServiciosId"] = new SelectList(_context.Set<Servicios>(), "ServicioID", "Tipo", servicioPrestado.ServiciosId);
            return View(servicioPrestado);
        }

        // POST: ServicioPrestados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiciosPrestadoId,HuespedId,ServiciosId,Resumen")] ServicioPrestado servicioPrestado)
        {
            if (id != servicioPrestado.ServiciosPrestadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioPrestado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioPrestadoExists(servicioPrestado.ServiciosPrestadoId))
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
            ViewData["HuespedId"] = new SelectList(_context.Huesped, "HuespedId", "Nombre", servicioPrestado.HuespedId);
            ViewData["ServiciosId"] = new SelectList(_context.Set<Servicios>(), "ServicioID", "Tipo", servicioPrestado.ServiciosId);
            return View(servicioPrestado);
        }

        // GET: ServicioPrestados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioPrestado = await _context.ServicioPrestado
                .Include(s => s.Huésped)
                .Include(s => s.Servicios)
                .FirstOrDefaultAsync(m => m.ServiciosPrestadoId == id);
            if (servicioPrestado == null)
            {
                return NotFound();
            }

            return View(servicioPrestado);
        }

        // POST: ServicioPrestados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioPrestado = await _context.ServicioPrestado.FindAsync(id);
            _context.ServicioPrestado.Remove(servicioPrestado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioPrestadoExists(int id)
        {
            return _context.ServicioPrestado.Any(e => e.ServiciosPrestadoId == id);
        }
    }
}
