using ProyectoBackendMINIDOC.Data;
using ProyectoBackendMINIDOC.Repositories.Implementation;
using ProyectoBackendMINIDOC.Repositories.Interfaces;
using ProyectoBackendMINIDOC.Services.Implementation;
using ProyectoBackendMINIDOC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProyectoBackendMINIDOC.Models.Entities.Auth;

var builder = WebApplication.CreateBuilder(args);

// ==========================================================
// 🔹 SERVICIOS BASE
// ==========================================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==========================================================
// 🔹 CORS - Permitir acceso desde el frontend
// ==========================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // URL de tu frontend React/Vite
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ==========================================================
// 🔹 CONEXIONES A BASES DE DATOS
// ==========================================================

// 🧩 Esquema viejo (solo lectura)
builder.Services.AddDbContext<MinidocOldContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinidocConnection")));

// 🧩 Esquema nuevo (minidocNEW)
builder.Services.AddDbContext<MinidocNewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinidocConnection")));

// 🧩 Base de autenticación (AuthArmas)
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// ==========================================================
// 🔹 IDENTITY (manejo de AspNetUsers de Auth API)
// ==========================================================
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// ==========================================================
// 🔹 INYECCIÓN DE DEPENDENCIAS
// ==========================================================

// --- Lookups ---
builder.Services.AddScoped<ILookupRepository, LookupRepository>();
builder.Services.AddScoped<ILookupService, LookupService>();

// --- Usuarios Minidoc ---
builder.Services.AddScoped<IUsuarioMinidocRepository, UsuarioMinidocRepository>();
builder.Services.AddScoped<IUsuarioMinidocService, UsuarioMinidocService>();

// --- Comunicación con AuthAPI ---
builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
    var baseUrl = builder.Configuration["AuthApi:BaseUrl"];
    if (string.IsNullOrEmpty(baseUrl))
        throw new InvalidOperationException("No se configuró AuthApi:BaseUrl en appsettings.json.");

    client.BaseAddress = new Uri(baseUrl);
    client.Timeout = TimeSpan.FromSeconds(10); // evita colgados si AuthAPI no responde
});

// ==========================================================
// 🔹 BUILD & MIDDLEWARE
// ==========================================================
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔧 Dejar HTTP habilitado durante desarrollo (sin HTTPS forzado)
// app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
