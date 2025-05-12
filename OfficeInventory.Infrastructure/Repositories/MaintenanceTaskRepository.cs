using Microsoft.EntityFrameworkCore;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;
using OfficeInventory.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Infrastructure.Repositories
{
    public class MaintenanceTaskRepository(InventaryDbContext context) : IMaintenanceTaskRepository
    {

        private readonly InventaryDbContext _context = context;

        public async Task<IEnumerable<MaintenanceTask>> GetAllAsync()
        {
            return await _context.MaintenanceTasks.ToListAsync();
        }

        public async Task<MaintenanceTask> GetByIdAsync(int id)
        {
            return await _context.MaintenanceTasks.FindAsync(id);
        }

        public async Task AddAsync(MaintenanceTask entity)
        {
            await _context.MaintenanceTasks.AddAsync(entity);
        }

        public void Update(MaintenanceTask entity)
        {
            _context.MaintenanceTasks.Update(entity);
        }

        public void Remove(MaintenanceTask entity)
        {
            _context.MaintenanceTasks.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
