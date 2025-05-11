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
    public class MaintenanceTaskService : IMaintenanceTaskService
    {
        private readonly InventaryDbContext _context;

        public MaintenanceTaskService(InventaryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceTaskDto>> GetAllAsync()
        {
            return await _context.MaintenanceTasks
                .Select(task => new MaintenanceTaskDto
                {
                    Id = task.Id,
                    Description = task.Description
                })
                .ToListAsync();
        }

        public async Task<MaintenanceTaskDto> GetByIdAsync(int id)
        {
            var task = await _context.MaintenanceTasks.FindAsync(id);
            if (task == null) return null;

            return new MaintenanceTaskDto
            {
                Id = task.Id,
                Description = task.Description
            };
        }

        public async Task<MaintenanceTaskDto> CreateAsync(MaintenanceTaskDto dto)
        {
            var entity = new MaintenanceTask
            {
                Description = dto.Description
            };

            _context.MaintenanceTasks.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, MaintenanceTaskDto dto)
        {
            var entity = await _context.MaintenanceTasks.FindAsync(id);
            if (entity == null) return false;

            entity.Description = dto.Description;
            _context.MaintenanceTasks.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.MaintenanceTasks.FindAsync(id);
            if (entity == null) return false;

            _context.MaintenanceTasks.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
