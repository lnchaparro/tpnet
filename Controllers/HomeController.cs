using CRUD1.Data;
using CRUD1.Models;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ProductoData productoData = new ProductoData();
        ProductoPromocionData productoPromocionData = new ProductoPromocionData();
        PromocionData promocionData = new PromocionData();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Listar()
        {
            var oListaProductos = productoData.Listar();
            var oListaPromos = productoPromocionData.Listar();

            // terrible O(n^2) pero para este trabajo practico esta bien porque hay pocos productos y pocas promociones
            foreach (ModelProducto producto in oListaProductos)
            {
                decimal descuentoTotal = 0;

                foreach (ModelProductoPromocion promo in oListaPromos)
                {
                    if (promo.productoID == producto.productoID)
                    {
                        producto.onSale = true;

                        ModelPromocion promoData = promocionData.Obtener(promo.promocionID);
                        descuentoTotal += promoData.descuento;
                    }
                }

                if (descuentoTotal > 0)
                {
                    producto.precio_promo = Decimal.Round((Decimal.Divide(descuentoTotal, 100) * producto.precio), 2);
                }


            }


            return View(oListaProductos);
        }

        public void Comprar(ModelProducto producto)
        {
            Console.WriteLine("Compraste " + producto.nom_producto);
        }

        public IActionResult Index()
        {
            return Listar();
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