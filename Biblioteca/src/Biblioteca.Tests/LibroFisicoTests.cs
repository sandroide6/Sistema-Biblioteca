using System;
using Biblioteca.Domain;
using Xunit;

namespace Biblioteca.Tests
{
    public class LibroFisicoTests
    {
        [Fact]
        public void CrearLibroFisico_DeberiaGuardarTituloYUbicacion()
        {
            // Arrange & Act
            var libro = new LibroFisico("1", "El Principito", "Estante A-3");

            // Assert
            Assert.Equal("1", libro.Id);
            Assert.Equal("El Principito", libro.Titulo);
            Assert.Equal("Estante A-3", libro.Ubicacion);
            Assert.True(libro.Disponible); // Por defecto debe estar disponible
        }

        [Fact]
        public void CrearLibroFisico_ConIdNuloOVacio_DeberiaLanzarExcepcion()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new LibroFisico(null, "Título", "Ubicación"));
            Assert.Throws<ArgumentException>(() => new LibroFisico("", "Título", "Ubicación"));
            Assert.Throws<ArgumentException>(() => new LibroFisico("   ", "Título", "Ubicación"));
        }

        [Fact]
        public void CrearLibroFisico_ConTituloNuloOVacio_DeberiaLanzarExcepcion()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new LibroFisico("1", null, "Ubicación"));
            Assert.Throws<ArgumentException>(() => new LibroFisico("1", "", "Ubicación"));
            Assert.Throws<ArgumentException>(() => new LibroFisico("1", "   ", "Ubicación"));
        }

        [Fact]
        public void CrearLibroFisico_DeberiaTrimarEspaciosEnBlanco()
        {
            // Arrange & Act
            var libro = new LibroFisico("  1  ", "  El Principito  ", "Estante A-3");

            // Assert
            Assert.Equal("1", libro.Id);
            Assert.Equal("El Principito", libro.Titulo);
        }

        [Fact]
        public void PrestarLibro_CuandoEstaDisponible_DeberiaMarcarComoNoDisponible()
        {
            // Arrange
            var libro = new LibroFisico("1", "El Principito", "Estante A-3");

            // Act
            libro.Prestar();

            // Assert
            Assert.False(libro.Disponible);
        }

        [Fact]
        public void PrestarLibro_CuandoYaEstaPrestado_DeberiaLanzarExcepcion()
        {
            // Arrange
            var libro = new LibroFisico("1", "El Principito", "Estante A-3");
            libro.Prestar();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => libro.Prestar());
        }

        [Fact]
        public void DevolverLibro_CuandoEstaPrestado_DeberiaMarcarComoDisponible()
        {
            // Arrange
            var libro = new LibroFisico("1", "El Principito", "Estante A-3");
            libro.Prestar();

            // Act
            libro.Devolver();

            // Assert
            Assert.True(libro.Disponible);
        }

        [Fact]
        public void DevolverLibro_CuandoYaEstaDisponible_DeberiaLanzarExcepcion()
        {
            // Arrange
            var libro = new LibroFisico("1", "El Principito", "Estante A-3");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => libro.Devolver());
        }
    }
}