using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductoController : Controller
    {
        ProductoData ProductoData = new ProductoData();

        public IActionResult Listar()
        {
            var oLista = ProductoData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelProducto oProducto)
        {
            var respuesta = ProductoData.Crear(oProducto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int id)
        {
            var oProducto = ProductoData.Obtener(id);

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Editar(ModelProducto oProducto)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = ProductoData.Editar(oProducto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int id)
        {
            var oProducto = ProductoData.Obtener(id);

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelProducto oProducto)
        {
            var respuesta = ProductoData.Eliminar(oProducto.productoID);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
