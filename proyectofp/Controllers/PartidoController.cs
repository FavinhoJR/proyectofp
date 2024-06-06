using Microsoft.AspNetCore.Mvc;
using proyectofp.Models;
using proyectofp.DataStructures;

namespace proyectofp.Controllers
{
    public class PartidoController : Controller
    {
        private static HashTable<string, Partido> partidos = new HashTable<string, Partido>(100);

        public IActionResult Index()
        {
            var listaPartidos = partidos.ToList();
            return View(listaPartidos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Partido partido)
        {
            string key = GenerateKey(partido);
            partidos.Insert(key, partido);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(string key)
        {
            var partido = partidos.Find(key);
            return View(partido);
        }

        [HttpPost]
        public IActionResult Editar(Partido partido, string key)
        {
            partidos.Update(key, partido);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(string key)
        {
            partidos.Delete(key);
            return RedirectToAction("Index");
        }

        private string GenerateKey(Partido partido)
        {
            return $"{partido.Fecha}-{partido.EquipoLocal.Nombre}-{partido.EquipoVisitante.Nombre}";
        }
    }
}