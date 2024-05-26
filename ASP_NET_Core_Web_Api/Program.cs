using ASP_NET_Core_Web_Api.Implementations;
using ASP_NET_Core_Web_Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Diferite moduri de a aduga servicii in containerul de servicii .DOT Net
builder.Services.AddSingleton(typeof(ServiceTest));
builder.Services.AddSingleton(typeof(IServiceTest), new ServiceTest());
builder.Services.AddSingleton(typeof(IServiceTest), typeof(ServiceTest));
builder.Services.AddSingleton(typeof(IServiceTest), (a) => { return new ServiceTest(); });
// ----------------------------------------------------------------------------------------
builder.Services.AddSingleton<ServiceTest>();
builder.Services.AddSingleton<IServiceTest>((a) => new ServiceTest());
builder.Services.AddSingleton<IServiceTest>(new ServiceTest());
builder.Services.AddSingleton<IServiceTest, ServiceTest>();
builder.Services.AddSingleton<IServiceTest, ServiceTest>((a) => { return new ServiceTest(); });


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
