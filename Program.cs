using encopav_api.Configurations;
using encopav_api.Repository;
using encopav_api.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();

var conexao = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddSingleton(CriarParametrosConexao(conexao));

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

static ConfiguracaoBanco CriarParametrosConexao(string parametro) => new() { MySQLConnectionString = parametro};