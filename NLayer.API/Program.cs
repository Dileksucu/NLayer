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

//Oluþturduðum interfaceleri AddScoped ile  bildiriyorum.
//Program.cs kirletmemek amacýyla Scopedlar için daha sonra dinamik olarak bir sýnýf oluþturacaðým. 
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); //Burada Typeof verme sebebim generic olmasý ýnterface'in
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

//Burada AutoMapper kütüphanesini bildirdik kullanabilmek için.
builder.Services.AddAutoMapper(typeof(MapProfile)); //Typeof ile tipini MapProfile olarak belirttik/bildirdik.

builder.Services.AddScoped<IProductRepository, ProductRepository>(); //Generic olmadýðýndan bu þekilde tanýmladýk.
builder.Services.AddScoped<IProductService, ProductService>();

//Db baðlantýsýný saðladýðýmýz kýsým
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
