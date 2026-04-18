using Lab4_Productos_C36462.Models;
using Lab4_Productos_C36462.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Productos_C36462.Controllers
{
    public class ProductosController : Controller
    {
        // GET: /Productos
        public IActionResult Index()
        {
            var productos = ProductoRepositorio.ObtenerTodos();
            return View(productos);
        }

        // GET: /Productos/Detalles/5
        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // GET: /Productos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Productos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            ProductoRepositorio.Agregar(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Productos/Editar/5
        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: /Productos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            ProductoRepositorio.Actualizar(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Productos/Eliminar/5
        public IActionResult Eliminar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: /Productos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}