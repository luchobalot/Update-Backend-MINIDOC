using ProyectoBackendMINIDOC.Data;
using ProyectoBackendMINIDOC.Repositories.Implementation;
using ProyectoBackendMINIDOC.Repositories.Interfaces;
using ProyectoBackendMINIDOC.Services.Implementation;
using ProyectoBackendMINIDOC.Services.Interfaces;
using ProyectoBackendMINIDOC.Models.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// ==========================================================
// 🔹 LOGGING
// ==========================================================
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// ==========================================================
// 🔹 SERVICIOS BASE
// ==========================================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==========================================================
// 🔹 CORS (para el frontend React en localhost:5173)
// ==========================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// ==========================================================
// 🔹 BASES DE DATOS
// ==========================================================
builder.Services.AddDbContext<MinidocOldContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinidocConnection")));

builder.Services.AddDbContext<MinidocNewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinidocConnection")));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// ==========================================================
// 🔹 IDENTITY (manejo de AspNetUsers)
// ==========================================================
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// ==========================================================
// 🔹 INYECCIÓN DE DEPENDENCIAS
// ==========================================================
builder.Services.AddScoped<ILookupRepository, LookupRepository>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<IUsuarioMinidocRepository, UsuarioMinidocRepository>();
builder.Services.AddScoped<IUsuarioMinidocService, UsuarioMinidocService>();

builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
    var baseUrl = builder.Configuration["AuthApi:BaseUrl"];
    if (string.IsNullOrEmpty(baseUrl))
        throw new InvalidOperationException("No se configuró AuthApi:BaseUrl en appsettings.json.");

    client.BaseAddress = new Uri(baseUrl);
    client.Timeout = TimeSpan.FromSeconds(15);
});

// ==========================================================
// 🔹 BUILD & MIDDLEWARE
// ==========================================================
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
