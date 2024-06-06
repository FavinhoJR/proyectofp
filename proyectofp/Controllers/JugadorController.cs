using Microsoft.AspNetCore.Mvc;
using proyectofp.Models;
using LinkedList = proyectofp.DataStructures.LinkedList<proyectofp.Models.Jugador>; // Alias para evitar conflicto

namespace proyectofp.Controllers
{
    public class JugadorController : Controller
    {
        private static LinkedList jugadores = new LinkedList();

        public IActionResult Index()
        {
            var listaJugadores = jugadores.ToList();
            return View(listaJugadores);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Jugador jugador)
        {
            jugadores.AddLast(jugador);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(string nombre)
        {
            var jugador = jugadores.Find(new Jugador { Nombre = nombre });
            return View(jugador);
        }

        [HttpPost]
        public IActionResult Editar(Jugador jugador)
        {
            jugadores.Delete(jugador);
            jugadores.AddLast(jugador);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(string nombre)
        {
            jugadores.Delete(new Jugador { Nombre = nombre });
            return RedirectToAction("Index");
        }
    }
}
