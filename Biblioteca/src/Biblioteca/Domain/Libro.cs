using System;

namespace Biblioteca.Domain
{
    public abstract class Libro
    {
        public string Id { get; }
        public string Titulo { get; private set; }
    
        public bool Disponible { get; private set; }

        protected Libro(string id, string titulo)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El Id del libro es obligatorio");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("El título del libro es obligatorio");


            Id = id.Trim();
            Titulo = titulo.Trim();
            Disponible = true;
        }

        public void Prestar()
        {
            if (!Disponible)
                throw new InvalidOperationException("El libro no está disponible");

            Disponible = false;
        }

        public void Devolver()
        {
            if (Disponible)
                throw new InvalidOperationException("El libro ya está marcado como disponible");

            Disponible = true;
        }
    }
}
