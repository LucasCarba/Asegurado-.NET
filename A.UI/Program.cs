using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using A.Aplicacion.Interfaces;
using A.Repositorios;
using A.Aplicacion.UseCases;
using Microsoft.EntityFrameworkCore;

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Crear BD --");
    context.Database.EnsureCreated();
    var connection = context.Database.GetDbConnection();
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
            }
}

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Tabla Vehiculo --");
    foreach (var v in context.Vehiculos)
        {
            Console.WriteLine($"{v.Id} {v.Dominio} {v.Marca} {v.AnioFabricacion} {v.TitularId}");
        }
}

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Tabla Titular --");
    foreach (var t in context.Titulares)
        {
            Console.WriteLine($"{t.Id} {t.DNI} {t.Apellido} {t.Nombre} {t.Telefono} {t.Direccion} {t.CorreoElectronico}");
        }
}

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Tabla Tercero --");
    foreach (var t in context.Terceros)
        {
            Console.WriteLine($"{t.Id} {t.DNI} {t.Apellido} {t.Nombre} {t.Telefono} {t.Aseguradora} {t.SiniestroId}");
        }
}

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Tabla Titular --");
    foreach (var t in context.Terceros)
        {
            Console.WriteLine($"{t.Id} {t.DNI} {t.Apellido} {t.Nombre} {t.Telefono} {t.Aseguradora} {t.SiniestroId}");
        }
}

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Tabla Poliza --");
    foreach (var p in context.Polizas)
        {
            Console.WriteLine($"{p.Id} {p.VehiculoId} {p.ValorAsegurado} {p.Franquicia} {p.TipoCobertura} {p.FechaInicioVigencia} {p.FechaFinVigencia}");
        }
}

using (var context = new AseguradoraContext())
{
    Console.WriteLine("-- Tabla Siniestro --");
    foreach (var s in context.Siniestros)
        {
            Console.WriteLine($"{s.Id} {s.PolizaId} {s.FechaIngreso} {s.FechaOcurrencia} {s.Direccion} {s.Descripcion}");
        }
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



//agregamos estos servicios al contenedor DI
builder.Services.AddTransient<AgregarVehiculoUseCase>();
builder.Services.AddTransient<ListarVehiculoUseCase>();
builder.Services.AddTransient<EliminarVehiculoUseCase>();
builder.Services.AddTransient<ModificarVehiculoUseCase>();
builder.Services.AddScoped<IVehiculos, repositorioVehiculo>();

builder.Services.AddTransient<AgregarTitularUseCase>();
builder.Services.AddTransient<ListarTitularesUseCase>();
builder.Services.AddTransient<ListarTitularConVehiculoUseCase>();
builder.Services.AddTransient<EliminarTitularUseCase>();
builder.Services.AddTransient<ModificarTitularUseCase>();
builder.Services.AddScoped<ITitular, repositorioTitular>();


builder.Services.AddTransient<AgregarTerceroUseCase>();
builder.Services.AddTransient<ListarTercerosUseCase>();
builder.Services.AddTransient<EliminarTerceroUseCase>();
builder.Services.AddTransient<ModificarTerceroUseCase>();
builder.Services.AddScoped<ITercero, repositorioTercero>();

builder.Services.AddTransient<AgregarPolizaUseCase>();
builder.Services.AddTransient<ListarPolizasUseCase>();
builder.Services.AddTransient<EliminarPolizaUseCase>();
builder.Services.AddTransient<ModificarPolizaUseCase>();
builder.Services.AddScoped<IPoliza, repositorioPolizas>();

builder.Services.AddTransient<AgregarSiniestroUseCase>();
builder.Services.AddTransient<ListarSiniestrosUseCase>();
builder.Services.AddTransient<EliminarSiniestroUseCase>();
builder.Services.AddTransient<ModificarSiniestroUseCase>();
builder.Services.AddScoped<ISiniestro, repositorioSiniestro>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();

