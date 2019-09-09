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
    public class TransportesController : Controller
    {
        private readonly CarritoContext _context;

        public TransportesController(CarritoContext context)
        {
            _context = context;
        }

        // GET: Transportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transporte.ToListAsync());
        }

        // GET: Transportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte
                .FirstOrDefaultAsync(m => m.TransporteID == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // GET: Transportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransporteID,TipoVehiculo,Marca,Placa,Color,Estado")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transporte);
        }

        // GET: Transportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransporteID,TipoVehiculo,Marca,Placa,Color,Estado")] Transporte transporte)
        {
            if (id != transporte.TransporteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteExists(transporte.TransporteID))
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
            return View(transporte);
        }

        // GET: Transportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transporte
                .FirstOrDefaultAsync(m => m.TransporteID == id);
            if (transporte == null)
            {
                return NotFound();
            }

            return View(transporte);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transporte = await _context.Transporte.FindAsync(id);
            _context.Transporte.Remove(transporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransporteExists(int id)
        {
            return _context.Transporte.Any(e => e.TransporteID == id);
        }
    }
}
