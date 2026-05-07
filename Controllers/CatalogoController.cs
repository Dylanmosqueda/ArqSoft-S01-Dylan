using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        // Lista estática con los datos de los videojuegos
        private static List<Item> _items = new()
        {
            new Item {
                Id = 1, Titulo = "Devil May Cry", Genero = "Hack and Slash", Ano = 2001,
                Consola = "PlayStation 2", Descripcion = "Videojuego que trata de un cazador de demonios",
                ImagenUrl = "https://www.bing.com/images/search?view=detailV2&ccid=he8NZoAx&id=2B99F73C509505582081CF0035CEA955D0B9C3F6&thid=OIP.he8NZoAxOG5m2mG34hJQkAHaEK&mediaurl=https%3a%2f%2fcdn.wccftech.com%2fwp-content%2fuploads%2f2017%2f11%2fDevil-May-Cry-5.jpg"
            },
            new Item {
                Id = 2, Titulo = "Castlevania Simphony of the night", Genero = "Metroidvania", Ano = 1997,
                Consola = "PlayStation 2", Descripcion = "Videojuego que trata de un cazador...",
                ImagenUrl = "https://www.bing.com/images/search?view=detailV2&ccid=fQNclEdr&id=D68AA6784032E3FE414AD49F95D17CF9CFFE602A&thid=OIP.fQNclEdrjpJltmON3EgAiQHaHa&mediaurl=https%3a%2f%2fi.pinimg.com%2foriginals%2f6b%2f9d%2fa8%2f6b9da8e5c6c95769fd705820e8dc3dee.jpg"
            },
            new Item {
                Id = 3, Titulo = "Resident Evil 4", Genero = "Survival Horror", Ano = 2005,
                Consola = "GameCube", Descripcion = "Videojuego que trata de un agente especial...",
                ImagenUrl = "https://www.bing.com/images/search?view=detailV2&ccid=aSQldxE%2b&id=166138622B76CDE39F4336270A52A1A212EC6C75&thid=OIP.aSQldxE-nSnd8-wXcYKhsQHaEK&mediaurl=https%3a%2f%2f4kwallpapers.com%2fimages%2fwallpapers%2fresident-evil-4-3840x2160-11094.jpg"
            },
            new Item {
                Id = 4, Titulo = "Halo", Genero = "Ciencia ficcion", Ano = 2001,
                Consola = "Xbox", Descripcion = "Videojuego que trata de un esparta que pelea con covenant",
                ImagenUrl = "https://www.bing.com/images/search?view=detailV2&ccid=MXa10XQI&id=A82CD68363998B9FA2D1557B5AA1DF5FACA7EFCA&thid=OIP.MXa10XQIFMkyEGWtSfpKNgHaEo&mediaurl=https%3a%2f%2fimages8.alphacoders.com%2f380%2f380714.jpg"
            },
            new Item {
                Id = 5, Titulo = "God of War", Genero ="Aventura", Ano = 2005,
                Consola = "PlayStation", Descripcion = "Videojuego que trata de un semidios que pelea con dioses",
                ImagenUrl = "https://www.bing.com/images/search?view=detailV2&ccid=adKlTTB0&id=31B3F2C42FA8BAEB0E4914848B7A340302D7CB82&thid=OIP.adKlTTB0gBTUF8Y-Xe5Xogod_of_war_son_of_kratos-1920x1080.jpg"
            }
        };

        // Acción para mostrar la lista (con filtro por género)
        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();


            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
        }

        // Acción para ver el detalle de un juego
        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }

        // Acción para mostrar el formulario de agregar (GET)
        public IActionResult Agregar()
        {
            return View();
        }

        // Acción para procesar el formulario de agregar (POST)
        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            // Generar ID automáticamente buscando el número más alto y sumando 1
            item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;

            // Si el usuario no puso URL, le ponemos una imagen genérica por defecto
            if (string.IsNullOrEmpty(item.ImagenUrl))
            {
                item.ImagenUrl = "https://via.placeholder.com/150";
            }

            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}
