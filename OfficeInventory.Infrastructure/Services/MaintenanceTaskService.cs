using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Infrastructure.Services
{
    //public class MaintenanceTaskService : IMaintenanceTaskService
    //{
    //    private readonly InventaryDbContext _context;

    //    public MaintenanceTaskService(InventaryDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<IEnumerable<MaintenanceTaskDto>> GetAllAsync()
    //    {
    //        return await _context.MaintenanceTasks
    //            .Select(task => new MaintenanceTaskDto
    //            {
    //                Id = task.Id,
    //                Description = task.Description
    //            })
    //            .ToListAsync();
    //    }

    //    public async Task<MaintenanceTaskDto> GetByIdAsync(int id)
    //    {
    //        var task = await _context.MaintenanceTasks.FindAsync(id);
    //        if (task == null) return null;

    //        return new MaintenanceTaskDto
    //        {
    //            Id = task.Id,
    //            Description = task.Description
    //        };
    //    }

    //    public async Task<MaintenanceTaskDto> CreateAsync(MaintenanceTaskDto dto)
    //    {
    //        var entity = new MaintenanceTask
    //        {
    //            Description = dto.Description
    //        };

    //        _context.MaintenanceTasks.Add(entity);
    //        await _context.SaveChangesAsync();

    //        dto.Id = entity.Id;
    //        return dto;
    //    }

    //    public async Task<bool> UpdateAsync(int id, MaintenanceTaskDto dto)
    //    {
    //        var entity = await _context.MaintenanceTasks.FindAsync(id);
    //        if (entity == null) return false;

    //        entity.Description = dto.Description;
    //        _context.MaintenanceTasks.Update(entity);
    //        await _context.SaveChangesAsync();
    //        return true;
    //    }

    //    public async Task<bool> DeleteAsync(int id)
    //    {
    //        var entity = await _context.MaintenanceTasks.FindAsync(id);
    //        if (entity == null) return false;

    //        _context.MaintenanceTasks.Remove(entity);
    //        await _context.SaveChangesAsync();
    //        return true;
    //    }
    //}.
      public class MaintenanceTaskService : IMaintenanceTaskService
    {
        private readonly IMaintenanceTaskRepository _repo;
        //private readonly IMaintenanceTaskMaintenanceRepository _maintenanceRepo;
        private readonly IValidator<MaintenanceTaskDto> _validator;

        public MaintenanceTaskService(IMaintenanceTaskRepository repo, IValidator<MaintenanceTaskDto> validator)
        {
            _repo = repo;
            _validator = validator;

        }

        public async Task<IEnumerable<MaintenanceTaskDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(e => new MaintenanceTaskDto
            {
                Id = e.Id,
                Description = e.Description
            });
        }

        public async Task<MaintenanceTaskDto> GetByIdAsync(int id)
        {
            var maintenance = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");
            return new MaintenanceTaskDto
            {
                Id = maintenance.Id,
                Description = maintenance.Description

            };
        }

        public async Task<MaintenanceTaskDto> CreateAsync(MaintenanceTaskDto dto)
        {
            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage);
                var errosMessages = string.Join(", ", errors);

                throw new InvalidOperationException(errosMessages);
            }

            var entity = new MaintenanceTask
            {
                Description = dto.Description
            };

            await _repo.AddAsync(entity);
            await _repo.SaveAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task UpdateAsync(int id, MaintenanceTaskDto dto)
        {
            var entity = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");
            entity.Description = dto.Description;
            _repo.Update(entity);
            await _repo.SaveAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");

            _repo.Remove(entity);
            await _repo.SaveAsync();
        }

        //public async Task<IEnumerable<MaintenanceTaskDto>> GetMaintenancesByMaintenanceTaskIdAsync(int equipmentId)
        //{
        //    var tasks = await _maintenanceRepo.GetTasksByMaintenanceTaskIdAsync(equipmentId);
        //    return tasks.Select(t => new MaintenanceTaskDto
        //    {
        //        Id = t.Id,
        //        Description = t.Description
        //    });
        //}
    }
}
