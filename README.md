# Sistema de Gestión de Biblioteca

## 📖 Descripción del Proyecto

Sistema de consola desarrollado en .NET 8 (C#) que permite gestionar el préstamo de libros en una biblioteca, aplicando los 4 pilares de la Programación Orientada a Objetos: **Encapsulamiento**, **Herencia**, **Polimorfismo** y **Abstracción**.

## 🎯 Caso de Negocio

**Problema:** Las bibliotecas necesitan un sistema eficiente para controlar el préstamo de libros físicos y digitales, validando disponibilidad, fechas de devolución y políticas específicas según el tipo de usuario.

**Usuarios:** Bibliotecarios y administradores del sistema.

**Valor:** Automatiza el control de préstamos, reduce errores manuales y mejora el seguimiento de la disponibilidad de recursos.

## ⚡ Requisitos del Sistema

- .NET 8 SDK
- Sistema operativo: Windows, Linux o macOS
- Terminal/Consola de comandos

## 🚀 Ejecución

### Ejecutar Aplicacion
cd SRC/Biblioteca
dotnet run

### Ejecutar Pruebas
cd SRC/Biblioteca.Tests
dotnet test

### Estrutura
SRC/
├── Biblioteca/                     (Proyecto principal)
│   ├── Application/
│   │   ├── IPoliticaPrestamo.cs    (Interface para políticas)
│   │   ├── PoliticaPrestamoDocente.cs
│   │   └── PoliticaPrestamoNormal.cs
│   ├── Domain/
│   │   ├── Libro.cs                (Clase abstracta base)
│   │   ├── LibroDigital.cs         (Herencia - libro con URL)
│   │   ├── LibroFisico.cs          (Herencia - libro con ubicación)
│   │   ├── Prestamo.cs             (Entidad préstamo con fechas)
│   │   ├── Socio.cs                (Entidad socio con tipo)
│   │   └── TipoSocio.cs            (Enum: Estudiante/Docente)
│   ├── Infrastructure/
│   │   └── RepositorioLibrosEnMemoria.cs
│   └── Program.cs                  (Punto de entrada y menú)
├── Biblioteca.Tests/               (Proyecto de pruebas)
│   ├── Biblioteca.Tests.csproj
│   └── LibroFisicoTests.cs         (Pruebas unitarias)
└── README.md
