using System;

namespace _1.__BFF.Models
{
    /// <summary>
    /// Clase para manejar el retorno de datos desde la api rick and morty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public Info info { get; set; }
        public List<T> Results { get; set; }   
    }

    /// <summary>
    /// Record para manejar Info y paginacion en el retorno de la api
    /// </summary>
    /// <param name="count"></param>
    /// <param name="pages"></param>
    /// <param name="next"></param>
    /// <param name="prev"></param>
    public record Info (int count,int pages,string next,string prev);

}

