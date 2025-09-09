namespace Biblioteca.Domain
{
    public class LibroDigital : Libro
    {
        public string Url { get; private set; }

        public LibroDigital(string id, string titulo, string url)
            : base(id, titulo)
        {
            Url = url;
        }
    }
}
