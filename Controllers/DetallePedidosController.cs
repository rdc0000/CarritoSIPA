using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Carrito.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Carrito.Controllers
{
    public class DetallePedidosController : Controller
    {
        private readonly CarritoContext _context;

        public DetallePedidosController(CarritoContext context)
        {
            _context = context;
        }

        // GET: DetallePedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetallePedido.ToListAsync());
        }
        public async Task<IActionResult> Siguiente()
        {
            return View(await _context.DetallePedido.ToListAsync());
        }
        public async Task<IActionResult> Edit()
        {
            return View(await _context.DetallePedido.ToListAsync());
        }


        public void SetSession(object obj)
        {
            HttpContext.Session.SetString("carrito", JsonConvert.SerializeObject(obj));
        }

        public string GetSession()
        {
            return HttpContext.Session.GetString("carrito");

        }

        [HttpPost]
        public string Agregar([FromBody] DetallePedido modelo)
        {
            if (GetSession() == null)
            {
                List<DetallePedido> lista = new List<DetallePedido>();
                lista.Add(modelo);
                SetSession(lista);
            }
            else
            {
                List<DetallePedido> lista = JsonConvert.DeserializeObject<List<DetallePedido>>(GetSession());
                lista.Add(modelo);
                SetSession(lista);
            }
            var value = GetSession();
            return value;
        }
        [HttpGet]
        public string Llenar()
        {
            var session = GetSession();
            return session;
        }

        [HttpPost]
        public void Editar([FromBody] DetallePedido modelo)
        {
            List<DetallePedido> lista = JsonConvert.DeserializeObject<List<DetallePedido>>(GetSession());
            var resultado = lista.FirstOrDefault(p => p.Articulo.ArticuloID == modelo.Articulo.ArticuloID);
            if (resultado != null)
            {
                resultado.Cantidad = modelo.Cantidad;
                resultado.Total = modelo.Total;
                resultado.PrecioTotal = modelo.PrecioTotal;
            }
            SetSession(lista);
        }
        [HttpPost]
        public string Eliminar(int articuloID)
        {
            List<DetallePedido> lista = JsonConvert.DeserializeObject<List<DetallePedido>>(GetSession());
            lista.RemoveAll(p => p.Articulo.ArticuloID == articuloID);
            SetSession(lista);
            var value = GetSession();
            return value;
        }
    }
}
