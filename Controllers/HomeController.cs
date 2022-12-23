﻿using CRUD1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
        }
        public IActionResult Empleados()
        {
            return View();
        }
        public IActionResult Productos()
        {
            return View();
        }
        public IActionResult Promociones()
        {
            return View();
        }
        public IActionResult OrdenesDeCompra()
        {
            return View();
        }
        public IActionResult Proveedores()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}