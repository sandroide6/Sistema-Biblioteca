using Biblioteca.Domain;
using System;
namespace Biblioteca.Application
{
    public interface IPoliticaPrestamo
    {
        DateTime CalcularFechaDevolucion(Socio socio, DateTime fechaPrestamo);
    }
}
