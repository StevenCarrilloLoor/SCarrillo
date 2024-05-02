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
    public class SCarrilloModelsController : Controller
    {
        private readonly SCarrilloContext _context;

        public SCarrilloModelsController(SCarrilloContext context)
        {
            _context = context;
        }

        // GET: SCarrilloModels
        public async Task<IActionResult> Index()
        {
            var sCarrilloContext = _context.SCarrillo.Include(s => s.Carrera);
            return View(await sCarrilloContext.ToListAsync());
        }

        // GET: SCarrilloModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCarrilloModel = await _context.SCarrillo
                .Include(s => s.Carrera)
                .FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (sCarrilloModel == null)
            {
                return NotFound();
            }

            return View(sCarrilloModel);
        }

        // GET: SCarrilloModels/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus");
            return View();
        }

        // POST: SCarrilloModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudianteId,Edad,Promedio,Nombre,Activo,FechaIngreso,CarreraId")] SCarrilloModel sCarrilloModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sCarrilloModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus", sCarrilloModel.CarreraId);
            return View(sCarrilloModel);
        }

        // GET: SCarrilloModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCarrilloModel = await _context.SCarrillo.FindAsync(id);
            if (sCarrilloModel == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus", sCarrilloModel.CarreraId);
            return View(sCarrilloModel);
        }

        // POST: SCarrilloModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudianteId,Edad,Promedio,Nombre,Activo,FechaIngreso,CarreraId")] SCarrilloModel sCarrilloModel)
        {
            if (id != sCarrilloModel.EstudianteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sCarrilloModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SCarrilloModelExists(sCarrilloModel.EstudianteId))
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
            ViewData["CarreraId"] = new SelectList(_context.Carrera, "CarreraId", "Campus", sCarrilloModel.CarreraId);
            return View(sCarrilloModel);
        }

        // GET: SCarrilloModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCarrilloModel = await _context.SCarrillo
                .Include(s => s.Carrera)
                .FirstOrDefaultAsync(m => m.EstudianteId == id);
            if (sCarrilloModel == null)
            {
                return NotFound();
            }

            return View(sCarrilloModel);
        }

        // POST: SCarrilloModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sCarrilloModel = await _context.SCarrillo.FindAsync(id);
            if (sCarrilloModel != null)
            {
                _context.SCarrillo.Remove(sCarrilloModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SCarrilloModelExists(int id)
        {
            return _context.SCarrillo.Any(e => e.EstudianteId == id);
        }
    }
}
