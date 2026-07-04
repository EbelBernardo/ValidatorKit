using Ebel.ValidationKit;
using Ebel.ValidationKit.Results;
using Ebel.ValidationKit.Validators;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.XPath;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Ebel.ValidationKit Demo API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configura o Swagger no pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ebel.ValidationKit Demo API v1");
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

var v1 = app.MapGroup("/api/v1");

v1.MapPost("/cpf/validator", (CpfRequest request) =>
{
    var result = request.Cpf.ValidateCpf();

    var response = new ValidationResponse
    {
        IsValid = result.IsValid,
        Code = result.Code.ToString(),
        Message = result.Message
    };

    return result.IsValid
        ? Results.Ok(response)
        : Results.BadRequest(response);
});

v1.MapPost("/name/validator", (NameRequest request) =>
{
    var result = request.Name.ValidateName();

    var response = new ValidationResponse
    {
        IsValid = result.IsValid,
        Code = result.Code.ToString(),
        Message = result.Message
    };

    return result.IsValid
        ? Results.Ok(response)
        : Results.BadRequest(response);
});

app.Run();