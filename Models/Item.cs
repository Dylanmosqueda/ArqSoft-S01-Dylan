namespace Catalogo.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Consola { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Campo para la imagen
        public string? ImagenUrl { get; set; }
    }
}
