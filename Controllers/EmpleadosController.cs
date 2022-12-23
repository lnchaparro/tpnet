using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmpleadosController : Controller
    {
        EmpleadosData EmpleadosData = new EmpleadosData();

        public IActionResult Listar()
        {
            var oLista = EmpleadosData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelEmpleados oEmpleado)
        {
            var respuesta = EmpleadosData.Crear(oEmpleado);

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
            var oEmpleado = EmpleadosData.Obtener(id);

            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Editar(ModelEmpleados oEmpleado)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = EmpleadosData.Editar(oEmpleado);

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
            var oEmpleado = EmpleadosData.Obtener(id);

            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelEmpleados oEmpleado)
        {
            var respuesta = EmpleadosData.Eliminar(oEmpleado.empleadosID);

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
