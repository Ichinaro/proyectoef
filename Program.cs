using Microsoft.AspNetCore.Mvc; // Importa el espacio de nombres necesario para utilizar características de ASP.NET Core MVC. como [FromServices]
using Microsoft.EntityFrameworkCore; // Importa el espacio de nombres necesario para trabajar con Entity Framework Core.
using proyectoef; // Importa el espacio de nombres de tu proyecto, que contiene los modelos y el contexto de datos

var builder = WebApplication.CreateBuilder(args); // Crea un constructor de aplicación web que configura los servicios y la aplicación web ASP.NET Core.

builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB")); 
// Registra el contexto de datos Tareascontext en el contenedor de Servicios de la aplicación, 
// configurándolo para usar una base de datos en memoria llamada "TareasDB".

var app = builder.Build(); // Construye la aplicación web a partir del constructor configurado.

app.MapGet("/", () => "Hell0 world!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbcontext) => {
  // Mapea una ruta HTTP GET "/dbconexion" a una función asincrónica que recibe un Tareascontext inyectado desde los servicios.

  dbcontext.Database.EnsureCreated(); 
  // Asegura que la base de datos en memoria esté creada. 
  // Este método crea la base de datos y el esquema si no existen.

  return Results.Ok("Base de datos en memoria: " + dbcontext.Database.IsInMemory()); 
  // Devuelve un resultado HTTP 200 OK con un mensaje indicando si la base de datos está en memoria.
});

app.Run(); // Inicia la aplicación web ASP.NET Core y comienza a escuchar las solicitudes HTTP.
