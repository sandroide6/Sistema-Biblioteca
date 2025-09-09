using Biblioteca.Domain;
using Biblioteca.Application;
using Biblioteca.Infrastructure;
using System.Globalization;
using System.Linq;

var repo = new RepositorioLibrosEnMemoria();
var prestamos = new List<Prestamo>();

Console.WriteLine("🏛️  Sistema de Gestión de Biblioteca");
Console.WriteLine("===================================");

while (true)
{
    MostrarMenu();
    var opcion = Console.ReadLine()?.Trim();
    
    if (opcion == "0") 
    {
        Console.WriteLine("👋 ¡Hasta luego!");
        break;
    }

    try
    {
        switch (opcion)
        {
            case "1":
                RegistrarLibro(repo);
                break;
            case "2":
                RegistrarSocio(repo);
                break;
            case "3":
                PrestarLibro(repo, prestamos);
                break;
            case "4":
                DevolverLibro(prestamos);
                break;
            case "5":
                ListarLibros(repo);
                break;
            default:
                Console.WriteLine("❌ Opción inválida. Por favor seleccione una opción del 0 al 5.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
    
    Console.WriteLine("\nPresione Enter para continuar...");
    Console.ReadLine();
}

static void MostrarMenu()
{
    Console.Clear();
    Console.WriteLine("\n📚 MENÚ PRINCIPAL");
    Console.WriteLine("==================");
    Console.WriteLine("1) 📖 Registrar libro");
    Console.WriteLine("2) 👤 Registrar socio");
    Console.WriteLine("3) 📤 Prestar libro");
    Console.WriteLine("4) 📥 Devolver libro");
    Console.WriteLine("5) 📋 Listar libros");
    Console.WriteLine("0) 🚪 Salir");
    Console.Write("\nSeleccione una opción: ");
}

static void RegistrarLibro(RepositorioLibrosEnMemoria repo)
{
    Console.WriteLine("\n📖 REGISTRO DE LIBRO");
    Console.WriteLine("=====================");
    
    Console.Write("Id del libro: ");
    var id = LeerTextoObligatorio();
    
    Console.Write("Título: ");
    var titulo = LeerTextoObligatorio();

    var tipo = LeerTipoLibro();

    if (tipo == 1)
    {
        Console.Write("Ubicación física: ");
        var ubicacion = LeerTextoObligatorio();
        repo.AgregarLibro(new LibroFisico(id, titulo, ubicacion));
    }
    else
    {
        Console.Write("URL del recurso: ");
        var url = LeerTextoObligatorio();
        repo.AgregarLibro(new LibroDigital(id, titulo, url));
    }

    Console.WriteLine("✅ Libro registrado correctamente");
}

static void RegistrarSocio(RepositorioLibrosEnMemoria repo)
{
    Console.WriteLine("\n👤 REGISTRO DE SOCIO");
    Console.WriteLine("====================");
    
    Console.Write("Id del socio: ");
    var id = LeerTextoObligatorio();
    
    Console.Write("Nombre completo: ");
    var nombre = LeerTextoObligatorio();

    var tipoSocio = LeerTipoSocio();

    repo.AgregarSocio(new Socio(id, nombre, tipoSocio));
    Console.WriteLine("✅ Socio registrado correctamente");
}

static void PrestarLibro(RepositorioLibrosEnMemoria repo, List<Prestamo> prestamos)
{
    Console.WriteLine("\n📤 PRÉSTAMO DE LIBRO");
    Console.WriteLine("====================");
    
    Console.Write("Id del socio: ");
    var idSocio = LeerTextoObligatorio();
    var socio = repo.ObtenerSocio(idSocio) ?? throw new Exception("No existe el socio especificado");
    
    Console.Write("Id del libro: ");
    var idLibro = LeerTextoObligatorio();
    var libro = repo.ObtenerLibro(idLibro) ?? throw new Exception("No existe el libro especificado");

    if (!libro.Disponible)
        throw new Exception("El libro no está disponible para préstamo");

    IPoliticaPrestamo politica = socio.Tipo == TipoSocio.Docente
        ? new PoliticaPrestamoDocente()
        : new PoliticaPrestamoNormal();

    var prestamo = new Prestamo(libro, socio, DateTime.Now, politica);
    prestamos.Add(prestamo);
    
    Console.WriteLine($"✅ Préstamo registrado exitosamente");
    Console.WriteLine($"📅 Fecha de devolución: {prestamo.FechaDevolucion:dd/MM/yyyy}");
    Console.WriteLine($"👤 Socio: {socio.Nombre} ({socio.Tipo})");
    Console.WriteLine($"📖 Libro: {libro.Titulo}");
}

static void DevolverLibro(List<Prestamo> prestamos)
{
    Console.WriteLine("\n📥 DEVOLUCIÓN DE LIBRO");
    Console.WriteLine("======================");
    
    if (!prestamos.Any())
    {
        Console.WriteLine("ℹ️  No hay libros en préstamo actualmente");
        return;
    }
    
    Console.Write("Id del libro a devolver: ");
    var idLibro = LeerTextoObligatorio();
    
    var prestamo = prestamos.FirstOrDefault(p => p.Libro.Id == idLibro);
    if (prestamo == null) 
        throw new Exception("Ese libro no está registrado como préstamo activo");

    prestamo.Devolver();
    prestamos.Remove(prestamo);
    
    Console.WriteLine("✅ Libro devuelto correctamente");
    Console.WriteLine($"📖 Libro: {prestamo.Libro.Titulo}");
    Console.WriteLine($"👤 Devuelto por: {prestamo.Socio.Nombre}");
}

static void ListarLibros(RepositorioLibrosEnMemoria repo)
{
    Console.WriteLine("\n📋 LISTADO DE LIBROS");
    Console.WriteLine("====================");
    
    var libros = repo.ListarLibros().ToList();
    
    if (!libros.Any())
    {
        Console.WriteLine("ℹ️  No hay libros registrados en la biblioteca");
        return;
    }

    Console.WriteLine($"{"ID",-10} {"TÍTULO",-30} {"TIPO",-10} {"DISPONIBLE",-12}");
    Console.WriteLine(new string('-', 65));
    
    foreach (var libro in libros)
    {
        var tipo = libro is LibroFisico ? "Físico" : "Digital";
        var disponible = libro.Disponible ? "✅ Sí" : "❌ No";
        Console.WriteLine($"{libro.Id,-10} {libro.Titulo,-30} {tipo,-10} {disponible,-12}");
    }
    
    Console.WriteLine($"\nTotal de libros: {libros.Count}");
    Console.WriteLine($"Disponibles: {libros.Count(l => l.Disponible)}");
    Console.WriteLine($"En préstamo: {libros.Count(l => !l.Disponible)}");
}

static string LeerTextoObligatorio()
{
    string? texto;
    do
    {
        texto = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(texto))
            Console.Write("❌ Este campo es obligatorio. Intente nuevamente: ");
    } while (string.IsNullOrEmpty(texto));
    
    return texto;
}

static int LeerTipoLibro()
{
    int tipo;
    do
    {
        Console.Write("Tipo de libro (1=Físico, 2=Digital): ");
        if (!int.TryParse(Console.ReadLine(), out tipo) || (tipo != 1 && tipo != 2))
            Console.WriteLine("❌ Debe ingresar 1 para Físico o 2 para Digital");
    } while (tipo != 1 && tipo != 2);
    
    return tipo;
}

static TipoSocio LeerTipoSocio()
{
    while (true)
    {
        Console.Write("Tipo de socio (1=Estudiante, 2=Docente): ");
        var opcion = Console.ReadLine()?.Trim();

        switch (opcion)
        {
            case "1":
                return TipoSocio.Estudiante;
            case "2":
                return TipoSocio.Docente;
            default:
                Console.WriteLine("❌ Opción inválida. Debe ingresar 1 para Estudiante o 2 para Docente");
                break;
        }
    }
}