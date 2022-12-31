using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{

    public class ProductoPromocionController : Controller
    {
        ProductoPromocionData ProductoPromocionData = new ProductoPromocionData();

        public IActionResult Listar()
        {
            var oLista = ProductoPromocionData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelProductoPromocion oProductoPromocion)
        {
            var respuesta = ProductoPromocionData.Crear(oProductoPromocion);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int producto_id, int promocion_id)
        {
            var oProductoPromocion = ProductoPromocionData.Obtener(producto_id, promocion_id);

            return View(oProductoPromocion);
        }

        [HttpPost]
        public IActionResult Editar(ModelProductoPromocion oProductoPromocion)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = ProductoPromocionData.Editar(oProductoPromocion);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int producto_id, int promocion_id)
        {
            var oProductoPromocion = ProductoPromocionData.Obtener(producto_id, promocion_id);

            return View(oProductoPromocion);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelProductoPromocion oProductoPromocion)
        {
            var respuesta = ProductoPromocionData.Eliminar(oProductoPromocion.productoID, oProductoPromocion.promocionID);

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
