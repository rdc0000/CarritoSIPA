using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carrito.Models;

namespace Carrito.Controllers
{
    public class AutoserviciosController : Controller
    {
        private readonly CarritoContext _context;

        public AutoserviciosController(CarritoContext context)
        {
            _context = context;
        }

        // GET: Autoservicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autoservicio.ToListAsync());
        }

        // GET: Autoservicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoservicio = await _context.Autoservicio
                .FirstOrDefaultAsync(m => m.AutoservicioID == id);
            if (autoservicio == null)
            {
                return NotFound();
            }

            return View(autoservicio);
        }

        // GET: Autoservicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autoservicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoservicioID,Nombre,Direccion,Telefono,Estado,Imagen")] Autoservicio autoservicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoservicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoservicio);
        }

        // GET: Autoservicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoservicio = await _context.Autoservicio.FindAsync(id);
            if (autoservicio == null)
            {
                return NotFound();
            }
            return View(autoservicio);
        }

        // POST: Autoservicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoservicioID,Nombre,Direccion,Telefono,Estado,Imagen")] Autoservicio autoservicio)
        {
            if (id != autoservicio.AutoservicioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoservicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoservicioExists(autoservicio.AutoservicioID))
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
            return View(autoservicio);
        }

        // GET: Autoservicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoservicio = await _context.Autoservicio
                .FirstOrDefaultAsync(m => m.AutoservicioID == id);
            if (autoservicio == null)
            {
                return NotFound();
            }

            return View(autoservicio);
        }

        // POST: Autoservicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoservicio = await _context.Autoservicio.FindAsync(id);
            _context.Autoservicio.Remove(autoservicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoservicioExists(int id)
        {
            return _context.Autoservicio.Any(e => e.AutoservicioID == id);
        }
    }
}
