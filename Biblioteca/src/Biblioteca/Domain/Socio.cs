using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Domain
{
    public class Socio
    {
        public string Id { get; }
        public string Nombre { get; private set; }
        public TipoSocio Tipo { get; private set; }

        private readonly List<Prestamo> _prestamos = new();
        public IReadOnlyCollection<Prestamo> Prestamos => _prestamos.AsReadOnly();

        public Socio(string id, string nombre, TipoSocio tipo)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("El Id del socio es obligatorio");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del socio es obligatorio");

            Id = id.Trim();
            Nombre = nombre.Trim();
            Tipo = tipo;
        }

        public void AgregarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo), "El préstamo no puede ser nulo");

            // RN-06: máximo 2 préstamos activos
            if (_prestamos.Count(p => !p.Devuelto) >= 2)
                throw new InvalidOperationException("El socio ya tiene el máximo de 2 préstamos activos");

            _prestamos.Add(prestamo);
        }

        public void QuitarPrestamo(Prestamo prestamo)
        {
            if (prestamo == null)
                throw new ArgumentNullException(nameof(prestamo), "El préstamo no puede ser nulo");

            if (!_prestamos.Contains(prestamo))
                throw new InvalidOperationException("El préstamo no pertenece a este socio");

            _prestamos.Remove(prestamo);
        }
    }
}
