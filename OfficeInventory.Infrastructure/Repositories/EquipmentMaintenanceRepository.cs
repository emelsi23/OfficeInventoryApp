using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;

namespace OfficeInventory.Infrastructure.Repositories
{
    public class EquipmentMaintenanceRepository(InventaryDbContext context) : IEquipmentMaintenanceRepository
    {
        private readonly InventaryDbContext _context = context;

        public async Task<IEnumerable<MaintenanceTask>> GetTasksByEquipmentIdAsync(int equipmentId)
        {
            return await _context.EquipmentMaintenances
                .Where(em => em.EquipmentId == equipmentId)
                .Select(em => em.MaintenanceTask)
                .ToListAsync();
        }


        public async Task<IEnumerable<Equipment>> GetEquipmentsByTaskId(int taskId)
        {
            return await _context.EquipmentMaintenances
                .Where(em => em.MaintenanceTaskId == taskId)
                .Select(em => em.Equipment)
                .ToListAsync();
        }
    }
}
