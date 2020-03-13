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
    public class CasasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Casas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Casa.Include(c => c.Responsable);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Casas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .Include(c => c.Responsable)
                .FirstOrDefaultAsync(m => m.CasaId == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // GET: Casas/Create
        public IActionResult Create()
        {
            ViewData["ResponsableId"] = new SelectList(_context.Set<Responsable>(), "ResponsableId", "Direccion");
            return View();
        }

        // POST: Casas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasaId,Descripcion,Ubicacion,Cantidad_Cuartos,Cantida_WC,ResponsableId")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResponsableId"] = new SelectList(_context.Set<Responsable>(), "ResponsableId", "Direccion", casa.ResponsableId);
            return View(casa);
        }

        // GET: Casas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }
            ViewData["ResponsableId"] = new SelectList(_context.Set<Responsable>(), "ResponsableId", "Direccion", casa.ResponsableId);
            return View(casa);
        }

        // POST: Casas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasaId,Descripcion,Ubicacion,Cantidad_Cuartos,Cantida_WC,ResponsableId")] Casa casa)
        {
            if (id != casa.CasaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaExists(casa.CasaId))
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
            ViewData["ResponsableId"] = new SelectList(_context.Set<Responsable>(), "ResponsableId", "Direccion", casa.ResponsableId);
            return View(casa);
        }

        // GET: Casas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .Include(c => c.Responsable)
                .FirstOrDefaultAsync(m => m.CasaId == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // POST: Casas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casa = await _context.Casa.FindAsync(id);
            _context.Casa.Remove(casa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(int id)
        {
            return _context.Casa.Any(e => e.CasaId == id);
        }
    }
}
