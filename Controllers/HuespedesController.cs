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
    public class HuespedesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HuespedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Huespedes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Huesped.ToListAsync());
        }

        // GET: Huespedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huesped
                .FirstOrDefaultAsync(m => m.HuespedId == id);
            if (huesped == null)
            {
                return NotFound();
            }

            return View(huesped);
        }

        // GET: Huespedes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Huespedes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HuespedId,Nombre,NombreAereolin,HoraDeLlegada,CantAcompañantes")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huesped);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(huesped);
        }

        // GET: Huespedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huesped.FindAsync(id);
            if (huesped == null)
            {
                return NotFound();
            }
            return View(huesped);
        }

        // POST: Huespedes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HuespedId,Nombre,NombreAereolin,HoraDeLlegada,CantAcompañantes")] Huesped huesped)
        {
            if (id != huesped.HuespedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huesped);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuespedExists(huesped.HuespedId))
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
            return View(huesped);
        }

        // GET: Huespedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huesped
                .FirstOrDefaultAsync(m => m.HuespedId == id);
            if (huesped == null)
            {
                return NotFound();
            }

            return View(huesped);
        }

        // POST: Huespedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huesped = await _context.Huesped.FindAsync(id);
            _context.Huesped.Remove(huesped);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuespedExists(int id)
        {
            return _context.Huesped.Any(e => e.HuespedId == id);
        }
    }
}
