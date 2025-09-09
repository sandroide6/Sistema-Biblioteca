using System;
using Biblioteca.Application;

namespace Biblioteca.Domain
{
    public class Prestamo
    {
        public Libro Libro { get; }
        public Socio Socio { get; }
        public DateTime FechaPrestamo { get; }
        public DateTime FechaDevolucion { get; }
        public bool Devuelto { get; private set; }

        public Prestamo(Libro libro, Socio socio, DateTime fechaPrestamo, IPoliticaPrestamo politica)
        {
            if (libro == null)
                throw new ArgumentNullException(nameof(libro), "El libro no puede ser nulo");

            if (socio == null)
                throw new ArgumentNullException(nameof(socio), "El socio no puede ser nulo");

            if (politica == null)
                throw new ArgumentNullException(nameof(politica), "Debe existir una política de préstamo");

            if (!libro.Disponible)
                throw new InvalidOperationException("El libro ya está prestado");

            Libro = libro;
            Socio = socio;
            FechaPrestamo = fechaPrestamo;

            FechaDevolucion = politica.CalcularFechaDevolucion(socio, fechaPrestamo);
            if (FechaDevolucion <= FechaPrestamo)
                throw new InvalidOperationException("La fecha de devolución debe ser posterior a la de préstamo");

            Devuelto = false;

            libro.Prestar();
            socio.AgregarPrestamo(this); // RN-06 se valida aquí
        }

        public void Devolver()
        {
            if (Devuelto)
                throw new InvalidOperationException("El libro ya fue devuelto");

            Libro.Devolver();
            Socio.QuitarPrestamo(this);
            Devuelto = true;
        }
    }
}
