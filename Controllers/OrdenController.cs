using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrdenController : Controller
    {
        OrdenData OrdenData = new OrdenData();

        public IActionResult Listar()
        {
            var oLista = OrdenData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelOrden oOrden)
        {
            var respuesta = OrdenData.Crear(oOrden);

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
            var oOrden = OrdenData.Obtener(id);

            return View(oOrden);
        }

        [HttpPost]
        public IActionResult Editar(ModelOrden oOrden)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = OrdenData.Editar(oOrden);

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
            var oOrden = OrdenData.Obtener(id);

            return View(oOrden);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelOrden oOrden)
        {
            var respuesta = OrdenData.Eliminar(oOrden.ordenID);

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
