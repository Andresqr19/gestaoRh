using gestaoRh.Api.Controllers;
using gestaoRh.Application.Services;
using gestaoRh.Infrastructure.Repositories;
using gestaoRh.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GestaoRhContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")) // String de conexão do appsettings.json
        .EnableSensitiveDataLogging(); // Habilita o logging sensível
});

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

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
