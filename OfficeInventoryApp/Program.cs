using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Infrastructure.Data;
using OfficeInventory.Infrastructure.Repositories;
using OfficeInventory.Application.Validators;
using OfficeInventory.Infrastructure.Services;
using FluentValidation.AspNetCore;
using OfficeInventoryApp.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseCors();

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
