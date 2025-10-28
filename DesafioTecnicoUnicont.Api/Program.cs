using DesafioTecnicoUnicont.Data.Context;
using DesafioTecnicoUnicont.Data.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inicializando injeção de dependência
builder.Services.AddDependencyInjection();

//inicializa Dbcontext com connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Ocorreu um erro ao conectar com o banco de dados.");
builder.Services.AddDbContext<DesafioTecnicoUnicontContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
