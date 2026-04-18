using Lab4_Productos_C36462.Models;

namespace Lab4_Productos_C36462.Models
{
    public static class ProductoRepositorio
    {
        private static List<Producto> _productos = new List<Producto>();
        private static int _siguienteId = 1;

        public static List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public static Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public static void Agregar(Producto producto)
        {
            producto.Id = _siguienteId++;
            _productos.Add(producto);
        }

        public static void Actualizar(Producto producto)
        {
            var existente = _productos.FirstOrDefault(p => p.Id == producto.Id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Precio = producto.Precio;
                existente.Categoria = producto.Categoria;
            }
        }

        public static void Eliminar(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
        }
    }
}
