using System;

namespace _1.__BFF.Models
{
    /// <summary>
    /// Modelo para manejar los episodios
    /// </summary>
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Air_date { get; set; }
        public string episode { get; set; }
        public string [] Characters { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }
}


