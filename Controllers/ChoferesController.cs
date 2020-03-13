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
    public class ChoferesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChoferesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Choferes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chofer.ToListAsync());
        }

        // GET: Choferes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chofer = await _context.Chofer
                .FirstOrDefaultAsync(m => m.CI == id);
            if (chofer == null)
            {
                return NotFound();
            }

            return View(chofer);
        }

        // GET: Choferes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Choferes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CI,Nombre,Telefono,Direccion")] Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chofer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chofer);
        }

        // GET: Choferes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chofer = await _context.Chofer.FindAsync(id);
            if (chofer == null)
            {
                return NotFound();
            }
            return View(chofer);
        }

        // POST: Choferes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CI,Nombre,Telefono,Direccion")] Chofer chofer)
        {
            if (id != chofer.CI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chofer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoferExists(chofer.CI))
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
            return View(chofer);
        }

        // GET: Choferes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chofer = await _context.Chofer
                .FirstOrDefaultAsync(m => m.CI == id);
            if (chofer == null)
            {
                return NotFound();
            }

            return View(chofer);
        }

        // POST: Choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chofer = await _context.Chofer.FindAsync(id);
            _context.Chofer.Remove(chofer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoferExists(int id)
        {
            return _context.Chofer.Any(e => e.CI == id);
        }
    }
}
