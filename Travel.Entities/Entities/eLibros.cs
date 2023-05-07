namespace Travel.Entities.Entities
{
    /// <summary>
    /// Clase que maneja la entidad Libros.
    /// </summary>
    public class eLibros
    {
        public int Id_Libro { get; set; }
        public int ISBN { get; set; }
        public int Id_Editorial { get; set; }
        public string? Titulo { get; set; }
        public string? Sinopsis { get; set; }
        public string? N_Paginas { get; set; }
        public string? Nombres_Autor { get; set; }
        public string? Nombre_Editorial { get; set; }
        public int Id_Autor { get; set; }
        public int Id_Autor_Libro { get; set; }
    }
}
