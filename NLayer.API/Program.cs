using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Context;
using NLayer.Repository.Repository;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Olu�turdu�um interfaceleri AddScoped ile  bildiriyorum.
//Program.cs kirletmemek amac�yla Scopedlar i�in daha sonra dinamik olarak bir s�n�f olu�turaca��m. 
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); //Burada Typeof verme sebebim generic olmas� �nterface'in
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

//Burada AutoMapper k�t�phanesini bildirdik kullanabilmek i�in.
builder.Services.AddAutoMapper(typeof(MapProfile)); //Typeof ile tipini MapProfile olarak belirttik/bildirdik.

builder.Services.AddScoped<IProductRepository, ProductRepository>(); //Generic olmad���ndan bu �ekilde tan�mlad�k.
builder.Services.AddScoped<IProductService, ProductService>();

//Db ba�lant�s�n� sa�lad���m�z k�s�m
builder.Services.AddDbContext<AppDbContext>(options => options
  .UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

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
