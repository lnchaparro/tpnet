using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class PromocionController : Controller
    {
        PromocionData PromocionData = new PromocionData();

        public IActionResult Listar()
        {
            var oLista = PromocionData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelPromocion oPromocion)
        {
            var respuesta = PromocionData.Crear(oPromocion);

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
            var oPromocion = PromocionData.Obtener(id);

            return View(oPromocion);
        }

        [HttpPost]
        public IActionResult Editar(ModelPromocion oPromocion)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = PromocionData.Editar(oPromocion);

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
            var oPromocion = PromocionData.Obtener(id);

            return View(oPromocion);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelPromocion oPromocion)
        {
            var respuesta = PromocionData.Eliminar(oPromocion.promocionID);

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
