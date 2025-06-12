using gestaoRh.Api.Controllers;
using gestaoRh.Application.Services;
using gestaoRh.Infrastructure.Repositories;
using gestaoRh.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000") // A origem do seu app React
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<GestaoRhContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging();
});

// Suas injeções de dependência
builder.Services.AddControllers().AddApplicationPart(typeof(UsuarioController).Assembly);
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddControllers().AddApplicationPart(typeof(EmpresaController).Assembly);
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

builder.Services.AddControllers().AddApplicationPart(typeof(PerfilUsuarioController).Assembly);
builder.Services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
builder.Services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();

builder.Services.AddControllers().AddApplicationPart(typeof(DocumentoController).Assembly);
builder.Services.AddScoped<IDocumentoRepository, DocumentoRepository>();
builder.Services.AddScoped<IDocumentoService, DocumentoService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Adicionado para manter a boa prática

// =====================================================================
// 3. Use a política de CORS que você criou
// A ordem é importante: deve vir antes de MapControllers()
// =====================================================================
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
