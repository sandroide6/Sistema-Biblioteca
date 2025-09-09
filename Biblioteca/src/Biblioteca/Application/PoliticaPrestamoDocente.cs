using Biblioteca.Domain;
using System;
namespace Biblioteca.Application
{
    // Política para docentes
    public class PoliticaPrestamoDocente : IPoliticaPrestamo
    {
        public DateTime CalcularFechaDevolucion(Socio socio, DateTime fechaPrestamo)
        {
            if (socio.Tipo != TipoSocio.Docente)
                throw new InvalidOperationException("Esta política solo aplica a docentes");

            return fechaPrestamo.AddDays(30); // RN-04
        }
    }
}
