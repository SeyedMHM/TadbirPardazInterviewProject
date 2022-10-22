using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TadbirPardazProject.Application.Common.Exceptions;
using TadbirPardazProject.Application.Products.Commands.Create;
using TadbirPardazProject.Application.Products.Queries.Common;
using TadbirPardazProject.Application.Products.Queries.GetById;
using TadbirPardazProject.Domain.Data;
using TadbirPardazProject.Domain.Invoices;
using TadbirPardazProject.Domain.Products;
using TadbirPardazProject.Infrastructure.Data;
using TadbirPardazProject.Infrastructure.Invoices;
using TadbirPardazProject.Infrastructure.Products;
using TadbirPardazProject.Shared.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    })
    ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(ProductGetResponse).Assembly);

builder.Services.AddScoped<IQueryUnitOfWork, QueryUnitOfWork>();
builder.Services.AddScoped<ICommandUnitOfWork, CommandUnitOfWork>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IInvoiceQueryRepository, InvoiceQueryRepository>();
builder.Services.AddScoped<IInvoiceCommandRepository, InvoiceCommandRepository>();

builder.Services.AddMediatR(typeof(ProductGetByIdQuery));
builder.Services.AddValidatorsFromAssembly(typeof(ProductCreateCommandValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAngularLocalOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

//Order Is Important => This Middleware it must be at the first of middlewares
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseCors("MyAngularLocalOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
