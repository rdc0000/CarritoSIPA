using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carrito.Models;
using Carrito.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Carrito.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly CarritoContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ArticulosController(CarritoContext context,
                                    IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var carritoContext = _context.Articulo.Include(a => a.Proveedor);
            return View(await carritoContext.ToListAsync());
        }

        public async Task<IActionResult> IndexCl()
        {
            var carritoContext = _context.Articulo.Include(a => a.Proveedor);
            return View(await carritoContext.ToListAsync());
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo
                .Include(a => a.Proveedor)
                .FirstOrDefaultAsync(m => m.ArticuloID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            ViewData["ProveedorID"] = new SelectList(_context.Proveedor, "ProveedorID", "ProveedorID");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticuloID,ProveedorID,Nombre,Precio,Cantidad,Imagen")] ArticuloCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Imagen != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagen.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Imagen.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Articulo newArticulo = new Articulo
                {
                    ProveedorID = model.ProveedorID,
                    Nombre = model.Nombre,
                    Precio = model.Precio,
                    Cantidad = model.Cantidad,
                    Imagen = uniqueFileName
                };

                _context.Add(newArticulo);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexCl", new { id = newArticulo.ArticuloID });
            }
            ViewData["ProveedorID"] = new SelectList(_context.Proveedor, "ProveedorID", "ProveedorID", model.Proveedor);
            return View(model);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["ProveedorID"] = new SelectList(_context.Proveedor, "ProveedorID", "ProveedorID", articulo.ProveedorID);
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticuloID,ProveedorID,Nombre,Precio,Cantidad,Imagen")] ArticuloCreateViewModel model)
        {
            if (id != model.ArticuloID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    string uniqueFileName = null;
                    if (model.Imagen != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagen.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Imagen.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                    Articulo newArticulo = new Articulo
                    {
                        ProveedorID = model.ProveedorID,
                        Nombre = model.Nombre,
                        Precio = model.Precio,
                        Cantidad = model.Cantidad,
                        Imagen = uniqueFileName
                    };                    
               
                _context.Add(newArticulo);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexCl", new { id = newArticulo.ArticuloID });
            }
            ViewData["ProveedorID"] = new SelectList(_context.Proveedor, "ProveedorID", "ProveedorID", model.ProveedorID);
            return View(model);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo
                .Include(a => a.Proveedor)
                .FirstOrDefaultAsync(m => m.ArticuloID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulo.FindAsync(id);
            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexCl));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ArticuloID == id);
        }
    }
}
