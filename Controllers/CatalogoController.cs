using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        // Lista estática con las URLs DIRECTAS corregidas
        private static List<Item> _items = new()
        {
            new Item {
                Id = 1, Titulo = "Devil May Cry", Genero = "Hack and Slash", Ano = 2001,
                Consola = "PlayStation 2", Descripcion = "Videojuego que trata de un cazador de demonios",
                // URL corregida a la portada del primer juego
                ImagenUrl = "https://images.hdqwalls.com/download/dante-in-devil-may-cry-5-4k-0r-2560x1440.jpg"
            },
            new Item {
                Id = 2, Titulo = "Castlevania Simphony of the night", Genero = "Metroidvania", Ano = 1997,
                Consola = "PlayStation", Descripcion = "Videojuego que trata de un cazador de vampiros en el castillo de Drácula",
                // URL corregida
                ImagenUrl = "https://tse2.mm.bing.net/th/id/OIP.Y4SAVYOvyo3dtymin9-_awHaEK?rs=1&pid=ImgDetMain&o=7&rm=3"
            },
            new Item {
                Id = 3, Titulo = "Resident Evil 4", Genero = "Survival Horror", Ano = 2005,
                Consola = "GameCube", Descripcion = "Videojuego que trata de un agente especial en una misión en España",
                // URL corregida
                ImagenUrl = "https://tse4.mm.bing.net/th/id/OIP.O4n-qkNaO5nWO0L6OKR2dgHaEK?rs=1&pid=ImgDetMain&o=7&rm=3"
            },
            new Item {
                Id = 4, Titulo = "Halo", Genero = "Ciencia ficcion", Ano = 2001,
                Consola = "Xbox", Descripcion = "Videojuego que trata de un espartano que pelea contra el Covenant",
                // URL corregida
                ImagenUrl = "https://tse4.mm.bing.net/th/id/OIP.tFBVKpjMidVymPgbDkeo0wHaEK?rs=1&pid=ImgDetMain&o=7&rm=3"
            },
            new Item {
                Id = 5, Titulo = "God of War", Genero ="Aventura", Ano = 2005,
                Consola = "PlayStation 2", Descripcion = "Videojuego que trata de un semidios que pelea con dioses griegos",
                // URL corregida
                ImagenUrl = "https://tse2.mm.bing.net/th/id/OIP.dmidYTqYnMY314BxxS0k4wHaEK?rs=1&pid=ImgDetMain&o=7&rm=3"
            }
        };

        // El resto de tus acciones (Index, Detalle, Agregar) se mantienen igual...

        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();

            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
        }

        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}