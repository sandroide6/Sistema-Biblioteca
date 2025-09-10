# Sistema de Gestión de Biblioteca

## 📖 Descripción del Proyecto

Sistema de consola desarrollado en .NET 8 (C#) que permite gestionar el préstamo de libros en una biblioteca, aplicando los 4 pilares de la Programación Orientada a Objetos

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


### 📌Menú Principal

📌Al ejecutar la aplicación, verás las siguientes opciones:

<img width="1052" height="340" alt="image" src="https://github.com/user-attachments/assets/55faea31-75d7-4510-83e9-55f39307d3a6" />



📌Registrar Libro:

<img width="1371" height="766" alt="cap2" src="https://github.com/user-attachments/assets/b86665e9-acdd-4f4e-8d74-34b61ae56df5" />



📌Listado de Libros:

<img width="1443" height="875" alt="cap1" src="https://github.com/user-attachments/assets/ffb602d6-7703-46fb-9a69-2faa24f47aee" />

## Cómo probar

A continuación se describe un flujo de prueba básico para validar el funcionamiento del sistema:

1. **Registrar un libro físico**
   - Ir al menú → opción **Agregar libro**.
   - Ingresar los datos (ID, título, autor, tipo = Físico).
   - El libro queda registrado en el sistema.

2. **Registrar un socio estudiante**
   - Ir al menú → opción **Registrar socio**.
   - Ingresar los datos (ID, nombre, tipo de socio = Estudiante).
   - El socio queda registrado en el sistema.

3. **Registrar un préstamo para el socio**
   - Ir al menú → opción **Registrar préstamo**.
   - Seleccionar el **socio estudiante** y el **libro físico** registrado.
   - El sistema valida la política de préstamo:
     - Estudiante → menos días disponibles.
     - Docente → más días disponibles.
   - El préstamo queda registrado.

4. **Listar préstamos y validar disponibilidad**
   - Ir al menú → opción **Listar préstamos**.
   - El sistema muestra:
     - Libros prestados.
     - Socios a quienes se prestó.
     - Tiempo de préstamo.
   - El libro aparece como **No disponible** hasta su devolución.


