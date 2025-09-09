using Biblioteca.Domain;

namespace Biblioteca.Infrastructure
{
    public class RepositorioLibrosEnMemoria
    {
        private readonly Dictionary<string, Libro> _libros = new();
        private readonly Dictionary<string, Socio> _socios = new();

        public void AgregarLibro(Libro libro)
        {
            if (_libros.ContainsKey(libro.Id))
                throw new InvalidOperationException($"Ya existe un libro con el Id {libro.Id}");
            
            _libros[libro.Id] = libro;
        }

        public Libro? ObtenerLibro(string id) => _libros.TryGetValue(id, out var libro) ? libro : null;
        public IEnumerable<Libro> ListarLibros() => _libros.Values;

        public void AgregarSocio(Socio socio)
        {
            if (_socios.ContainsKey(socio.Id))
                throw new InvalidOperationException($"Ya existe un socio con el Id {socio.Id}");
            
            _socios[socio.Id] = socio;
        }

        public Socio? ObtenerSocio(string id) => _socios.TryGetValue(id, out var socio) ? socio : null;
        public IEnumerable<Socio> ListarSocios() => _socios.Values;
    }
}
