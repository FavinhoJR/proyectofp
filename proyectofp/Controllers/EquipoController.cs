using Microsoft.AspNetCore.Mvc;
using proyectofp.Models;
using proyectofp.DataStructures;

namespace proyectofp.Controllers
{
    public class EquipoController : Controller
    {
        private static AVLTree<Equipo> equipos = new AVLTree<Equipo>();

        public IActionResult Index()
        {
            var listaEquipos = equipos.ToList();
            return View(listaEquipos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Equipo equipo)
        {
            equipos.Insert(equipo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(string nombre)
        {
            var equipo = equipos.Find(new Equipo { Nombre = nombre });
            return View(equipo);
        }

        [HttpPost]
        public IActionResult Editar(Equipo equipo)
        {
            equipos.Delete(equipo);
            equipos.Insert(equipo);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(string nombre)
        {
            equipos.Delete(new Equipo { Nombre = nombre });
            return RedirectToAction("Index");
        }
    }
}