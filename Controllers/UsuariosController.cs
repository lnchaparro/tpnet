using Microsoft.AspNetCore.Mvc;
using CRUD1.Data;
using CRUD1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUD1.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsuariosController : Controller
    {
        UsuariosData UsuariosData = new UsuariosData();

        public IActionResult Listar()
        {
            var oLista = UsuariosData.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ModelUsuarios oUsuario)
        {
            var respuesta = UsuariosData.Crear(oUsuario);

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
            var oUsuario = UsuariosData.Obtener(id);

            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Editar(ModelUsuarios oUsuario)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = UsuariosData.Editar(oUsuario);

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
            var oUsuario = UsuariosData.Obtener(id);

            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelUsuarios oUsuario)
        {
            var respuesta = UsuariosData.Eliminar(oUsuario.id_usuario);

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
