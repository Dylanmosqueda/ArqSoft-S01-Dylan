using System.IO.Pipes;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new()
        {
            new Item { Id = 1, Titulo = "Devil May Cry", Genero = "Hack and Slash", Ano = 2001, Consola = "PlayStation 2", Descripcion = "Videojuego que trata de un cazador de demonios"},
            new Item { Id = 2, Titulo = "Castlevania Simphony of the night ", Genero = "Metroidvania", Ano = 1997, Consola = "PlayStation 2", Descripcion = "Videojuego que trata de un cazador..."},
            new Item { Id = 3, Titulo = "Resident Evil 4", Genero = "Survival Horror", Ano = 2005, Consola = "GameCube", Descripcion = "Videojuego que trata de un agente especial..."},
            new Item { Id = 4, Titulo = "Halo", Genero = "Ciencia ficcion", Ano = 2001, Consola = "Xbox", Descripcion = "Videojuego que trata de un esparta que pelea con covenant" },
            new Item { Id = 5, Titulo = "God of War", Genero ="Aventura", Ano = 2005, Consola = "PlayStation", Descripcion = "Videojuego que trata de un semidios que pelea con dioses"},
        };
            public IActionResult Index(string? genero)
        {
            var resultado = string .IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList(); 
            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;
            return
            View(resultado);
        }

        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null
            ? NotFound() : View(item);
        }

        public IActionResult Agregar ()
        {
            return View();
        }
        // Formulario — POST
        [ HttpPost ]
        public  IActionResult  Agregar (Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return RedirectToAction( "Index");

        }
         
    }
}
