using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class ClientesController : Controller
    {
        ClientesData clientesData = new ClientesData();

        public IActionResult Listar()
        {
            var oLista = clientesData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelClientes oCliente)
        {
            var respuesta = clientesData.Crear(oCliente);

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
            var oCliente = clientesData.Obtener(id);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Editar(ModelClientes oCliente)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = clientesData.Editar(oCliente);

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
            var oCliente = clientesData.Obtener(id);

            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelClientes oCliente)
        {
            var respuesta = clientesData.Eliminar(oCliente.clientes_ID);

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
