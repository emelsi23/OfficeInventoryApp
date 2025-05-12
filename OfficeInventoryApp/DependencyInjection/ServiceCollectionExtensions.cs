using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Application.Validators;
using OfficeInventory.Infrastructure.Data;
using OfficeInventory.Infrastructure.Repositories;
using OfficeInventory.Infrastructure.Services;

namespace OfficeInventoryApp.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<InventaryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Repositories
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IMaintenanceTaskRepository, MaintenanceTaskRepository>();
            services.AddScoped<IEquipmentMaintenanceRepository, EquipmentMaintenanceRepository>();

            // Services
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IMaintenanceTaskService, MaintenanceTaskService>();

            // Validators
            services.AddScoped<IValidator<MaintenanceTaskDto>, MaintenanceTaskDtoValidator>();

            // Controllers + FluentValidation
            services.AddControllers();
            services.AddValidatorsFromAssemblyContaining<EquipmentDtoValidator>();
     

            // Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
