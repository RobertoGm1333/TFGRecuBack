using ProtectoraAPI.Controllers;
using ProtectoraAPI.Repositories;
using ProtectoraAPI.Services;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GatosDB");

// Repositorios
builder.Services.AddScoped<IGatoRepository, GatoRepository>(provider =>
    new GatoRepository(connectionString));

builder.Services.AddScoped<IProtectoraRepository, ProtectoraRepository>(provider =>
    new ProtectoraRepository(connectionString));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(provider =>
    new UsuarioRepository(connectionString));

builder.Services.AddScoped<IDeseadoRepository, DeseadoRepository>(provider =>
    new DeseadoRepository(connectionString));

builder.Services.AddScoped<ISolicitudAdopcionRepository, SolicitudAdopcionRepository>(provider =>
    new SolicitudAdopcionRepository(connectionString));

// NUEVO: Adopcion
builder.Services.AddScoped<IAdopcionRepository, AdopcionRepository>(provider =>
    new AdopcionRepository(connectionString));

builder.Services.AddScoped<IEventoRepository, EventoRepository>(provider =>
    new EventoRepository(connectionString));

builder.Services.AddHttpClient<ICatherineRepository, CatherineRepository>(client =>
{
    var secs = builder.Configuration.GetValue<int?>("Ollama:TimeoutSeconds") ?? 180;
    client.Timeout = TimeSpan.FromSeconds(secs);
});

// CACHE para acelerar lecturas del catálogo
builder.Services.AddMemoryCache();

// Servicios
builder.Services.AddScoped<IGatoService, GatoService>(provider =>
    new GatoService(provider.GetRequiredService<IGatoRepository>()));

builder.Services.AddScoped<IProtectoraService, ProtectoraService>(provider =>
    new ProtectoraService(provider.GetRequiredService<IProtectoraRepository>()));

builder.Services.AddScoped<IUsuarioService, UsuarioService>(provider =>
    new UsuarioService(provider.GetRequiredService<IUsuarioRepository>()));

builder.Services.AddScoped<IDeseadoService, DeseadoService>(provider =>
    new DeseadoService(provider.GetRequiredService<IDeseadoRepository>()));

builder.Services.AddScoped<ISolicitudAdopcionService, SolicitudAdopcionService>(provider =>
    new SolicitudAdopcionService(provider.GetRequiredService<ISolicitudAdopcionRepository>()));

builder.Services.AddScoped<IAdopcionService, AdopcionService>(provider =>
    new AdopcionService(provider.GetRequiredService<IAdopcionRepository>()));

builder.Services.AddScoped<IEventoService, EventoService>(provider =>
    new EventoService(provider.GetRequiredService<IEventoRepository>())
);


// Servicio Catherine (IA)
builder.Services.AddScoped<ICatherineService, CatherineService>();

var AllowAll = "_AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Controladores + JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Aumentar límites para multipart (subida de imágenes)
builder.Services.Configure<FormOptions>(o =>
{
    o.MultipartBodyLengthLimit = 104857600; // 100 MB
    o.ValueLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();

// Archivos estáticos (wwwroot)
app.UseStaticFiles();
 
app.MapControllers();

app.Run();
