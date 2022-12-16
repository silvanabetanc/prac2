using BP.Comun.Centralizada;
using BP.Comun.Centralizada.Interfaces;
using BP.Comun.Logs;
using BP.EventBus;
using BP.EventBus.Interfaces;
using BP.EventBus.Logs;
using Microsoft.OpenApi.Models;
using srbetancBBDDSQl.API;
using srbetancBBDDSQl.Domain.Interfaces.Instancias.InstanciaUno;
using srbetancBBDDSQl.Domain.Interfaces.Kafka;
using srbetancBBDDSQl.Domain.Interfaces.ProductosReferidos;
using srbetancBBDDSQl.Domain.Interfaces.Propiedades;
using srbetancBBDDSQl.Infrastructure.Instancias.InstanciaUno;
using srbetancBBDDSQl.Infrastructure.ProductosReferidos;
using srbetancBBDDSQl.Repositorio.Configuraciones.Persistencias.BDDOrigen;
using srbetancBBDDSQl.Repository.Configuraciones.Api;
using srbetancBBDDSQl.Repository.Configuraciones.Centralizada;
using srbetancBBDDSQl.Repository.Configuraciones.Kafka;
using srbetancBBDDSQl.Repository.Configuraciones.Persistencias.InstanciaUno;
using srbetancBBDDSQl.Repository.Instancias.InstanciaUno;
using srbetancBBDDSQl.Repository.ProductosReferidos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region REPOSITORIOS
builder.Services.AddSingleton<IInstanciaUnoRepositorio, InstanciaUnoRepositorio>();
builder.Services.AddSingleton<IProductosReferidosRepositorio, ProductosReferidosRepositorio>();

#endregion REPOSITORIOS

#region INFRAESTRUCTURA
builder.Services.AddSingleton<IInstanciaUnoInfraestructura, InstanciaUnoInfraestructura>();
builder.Services.AddSingleton<IProductosReferidosInfraestructura, ProductosReferidosInfraestructura>();

#endregion INFRAESTRUCTURA

#region BD
builder.Services.AddSingleton<IWrapperDbContext, WrapperDbContext>();
builder.Services.AddSingleton<IWrapperDbContextCd, WrapperDbContextCd>();

#endregion BD

#region Kafka
builder.Services.AddSingleton<ILogs, Logs>();
builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>();
builder.Services.AddSingleton<IConfiguradorEventBus, ConfiguracionKafka>();
builder.Services.AddTransient<IRepositorioGenerico, RepositorioGenerico>();
#endregion Kafka

#region CONFIGURADORES CENTRALIZADA

builder.Services.AddSingleton<IPropiedadesApi, PropiedadesApi>();
builder.Services.AddSingleton<IConfiguradorCentralizada, ConfiguradorCentralizada>();
builder.Services.AddSingleton<IConfiguracionCentralizada, ConfiguracionCentralizada>();

#endregion

#region POLITICA PARA DOMINIO CRUZADO 

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                   .AllowAnyMethod()
                                                   .AllowAnyHeader()));
#endregion POLITICA PARA DOMINIO CRUZADO

#region SWAGGER HEADER

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "wspruebas",
        Description = "Servicio base para invocar servicios externos",
        Contact = new OpenApiContact
        {
            Name = "Banco Pichincha",
            Email = "devops@pichincha.com",
            Url = new Uri("https://www.pichincha.com"),
        }
    });

});

#endregion SWAGGER

#region MANEJO DE VERSIONES DE API

builder.Services.AddApiVersioning(options => options.UseApiBehavior = true);
builder.Services.AddApiVersioning(options => options.AssumeDefaultVersionWhenUnspecified = true);

#endregion MANEJO DE VERSIONES DE API FIN

#region INICIALIZAR CENTRALIZADA
try
{
    builder.Services.AddHostedService<InitConfig>();
}
catch (Exception)
{
}
#endregion INICIALIZAR CENTRALIZADA

#region INICIALIZAR COMPONENTE DE LOGS
builder.Services.AddLogs();
#endregion INICIALIZAR COMPONENTE DE LOGS



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
