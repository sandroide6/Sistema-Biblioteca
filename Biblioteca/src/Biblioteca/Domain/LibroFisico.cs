
using System;

namespace Biblioteca.Domain
{
    public class LibroFisico : Libro
    {
        public string Ubicacion { get; private set; }

        public LibroFisico(string id, string titulo, string ubicacion)
            : base(id, titulo)
        {
            if (string.IsNullOrWhiteSpace(ubicacion))
                throw new ArgumentException("La ubicación del libro es obligatoria");

            Ubicacion = ubicacion.Trim();
        }
    }
}