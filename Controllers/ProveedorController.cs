using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProveedorController : Controller
    {
        ProveedorData ProveedorData = new ProveedorData();

        public IActionResult Listar()
        {
            var oLista = ProveedorData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelProveedor oProveedor)
        {
            var respuesta = ProveedorData.Crear(oProveedor);

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
            var oProveedor = ProveedorData.Obtener(id);

            return View(oProveedor);
        }

        [HttpPost]
        public IActionResult Editar(ModelProveedor oProveedor)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = ProveedorData.Editar(oProveedor);

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
            var oProveedor = ProveedorData.Obtener(id);

            return View(oProveedor);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelProveedor oProveedor)
        {
            var respuesta = ProveedorData.Eliminar(oProveedor.proveedorID);

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
