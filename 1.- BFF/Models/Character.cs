using System;

namespace _1.__BFF.Models
{
    /// <summary>
    /// Modelo para manejar los Personajes
    /// </summary>
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public Origin origin { get; set; }
        public Location location { get; set; }
        public string Image { get; set; }
        public string [] Episode { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }

    /// <summary>
    /// Record para manejar objeto Origin de los personajes
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Url"></param>
    public record Origin (string Name, string Url);

    /// <summary>
    /// Record para manejar objeto Location de los personajes
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Url"></param>
    public record Location(string Name, string Url);

}


