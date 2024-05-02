using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCarrillo.Data;
using SCarrillo.Models;

namespace SCarrillo.Controllers
{
    public class SCarrilloesController : Controller
    {
        private readonly SCarrilloContext _context;

        public SCarrilloesController(SCarrilloContext context)
        {
            _context = context;
        }

        // GET: SCarrilloes
        public async Task<IActionResult> Index()
        {
            var sCarrilloContext = _context.SCarrillo.Include(s => s.Carrera);
            return View(await sCarrilloContext.ToListAsync());
        }

        // GET: SCarrilloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCarrillo = await _context.SCarrillo
                .Include(s => s.Carrera)
                .FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (sCarrillo == null)
            {
                return NotFound();
            }

            return View(sCarrillo);
        }

        // GET: SCarrilloes/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus");
            return View();
        }

        // POST: SCarrilloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudianteId,Edad,Promedio,Nombre,Activo,FechaIngreso,CarreraId")] SCarrillo sCarrillo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sCarrillo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus", sCarrillo.CarreraId);
            return View(sCarrillo);
        }

        // GET: SCarrilloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCarrillo = await _context.SCarrillo.FindAsync(id);
            if (sCarrillo == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus", sCarrillo.CarreraId);
            return View(sCarrillo);
        }

        // POST: SCarrilloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudianteId,Edad,Promedio,Nombre,Activo,FechaIngreso,CarreraId")] SCarrillo sCarrillo)
        {
            if (id != sCarrillo.EstudianteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sCarrillo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SCarrilloExists(sCarrillo.EstudianteId))
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
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus", sCarrillo.CarreraId);
            return View(sCarrillo);
        }

        // GET: SCarrilloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCarrillo = await _context.SCarrillo
                .Include(s => s.Carrera)
                .FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (sCarrillo == null)
            {
                return NotFound();
            }

            return View(sCarrillo);
        }

        // POST: SCarrilloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sCarrillo = await _context.SCarrillo.FindAsync(id);
            if (sCarrillo != null)
            {
                _context.SCarrillo.Remove(sCarrillo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SCarrilloExists(int id)
        {
            return _context.SCarrillo.Any(e => e.EstudianteId == id);
        }
    }
}
