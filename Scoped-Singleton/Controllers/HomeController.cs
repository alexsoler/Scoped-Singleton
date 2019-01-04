using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scoped_Singleton.Models;
using Scoped_Singleton.Services;

namespace Scoped_Singleton.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Registro> db;

        public HomeController(IGenericRepository<Registro> _db) => db = _db;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ListaRegistros()
        {
            return View(await db.ListaCompleta());
        }

        public IActionResult CrearRegistro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearRegistro([Bind("Id,Descripcion")]Registro registro)
        {
            if(ModelState.IsValid)
            {
                await db.AddRegistroAsync(registro);
                return RedirectToAction(nameof(Index));
            }

            return View(registro);
        }

        public IActionResult Contador()
        {
            var arreglo = new int[2];

            arreglo[0] = RepositorioGenerico<Registro>.contador;
            arreglo[1] = AplicationDbContext.contador;
            return Json(arreglo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
