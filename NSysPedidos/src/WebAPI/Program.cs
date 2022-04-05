using Application;
using Persistence;
using Shared;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AgregaSerilog();

// Add services to the container.
builder.Services.AgregaShared();
builder.Services.AgregaPersistenciaInfra(builder.Configuration);
builder.Services.AgregaAplicacion();
builder.Services.AddControllers();
builder.Services.AgregaVersionado();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UsarManejadorErroresMiddleware();

app.MapControllers();

app.Run();
