using Microsoft.AspNetCore.Mvc;
using MatrioshkaBookingSystem.Models;

public class HotelController : Controller
{
    // Este campo guarda la referencia al DbContext.
    // El DbContext es tu puente mágico hacia MySQL:
    // con él podés leer tablas, insertar, actualizar, eliminar, etc.
    private readonly BookingDbContext _context;

    // Constructor del controlador.
    // ASP.NET se encarga de "inyectar" (dependency injection)
    // una instancia lista del BookingDbContext cuando este controlador se crea.
    public HotelController(BookingDbContext context)
    {
        // Guardamos el DbContext en la variable _context
        // para usarlo en cualquier acción de este controlador.
        _context = context;
    }

    // Acción principal: responde a /Hotel o /Hotel/Index
    public IActionResult Index()
    {
        // _context.Hotels representa la tabla "Hotels" de tu base de datos.
        // .ToList() ejecuta una consulta SQL detrás de escena:
        //      SELECT * FROM Hotels;
        // Y convierte cada fila en un objeto C# tipo Hotel.
        var hoteles = _context.Hotels.ToList();

        // Enviamos la lista de hoteles a la vista "Index.cshtml".
        // La vista podrá iterar sobre el modelo y mostrar datos al usuario.
        return View(hoteles);
    }
}
