# Sistema de Gestión de Biblioteca

## 📖 Descripción del Proyecto

Sistema de consola desarrollado en .NET 8 (C#) que permite gestionar el préstamo de libros en una biblioteca, aplicando los 4 pilares de la Programación Orientada a Objetos: **Encapsulamiento**, **Herencia**, **Polimorfismo** y **Abstracción**.

El sistema está diseñado con una arquitectura en capas que separa las responsabilidades en:

Domain → Entidades principales como Libro, Socio, Prestamo.

Application → Interfaces y reglas de negocio (ILibroRepositorio).

Infrastructure → Implementaciones de persistencia (Memoria y JSON).

ConsoleApp → Aplicación de consola con menú interactivo.

Tests → Pruebas unitarias con xUnit.


## ⚡ Requisitos del Sistema

- .NET 8 SDK
- Sistema operativo: Windows, Linux o macOS
- Terminal/Consola de comandos

## 🚀 Ejecución

### Ejecutar la aplicacion

cd SRC/Biblioteca
dotnet run

### Ejecutar las Pruebas

cd SRC/Biblioteca.Tests
dotnet test

### Menú Principal

Al ejecutar la aplicación, verás las siguientes opciones:
<img width="1052" height="340" alt="image" src="https://github.com/user-attachments/assets/55faea31-75d7-4510-83e9-55f39307d3a6" />


