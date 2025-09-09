using Biblioteca.Domain;
using System;
namespace Biblioteca.Application
{
    // Política para estudiantes
    public class PoliticaPrestamoNormal : IPoliticaPrestamo
    {
        public DateTime CalcularFechaDevolucion(Socio socio, DateTime fechaPrestamo)
        {
            if (socio.Tipo != TipoSocio.Estudiante)
                throw new InvalidOperationException("Esta política solo aplica a estudiantes");

            return fechaPrestamo.AddDays(15); // RN-03
        }
    }
}
