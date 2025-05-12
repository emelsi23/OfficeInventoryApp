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


        public async Task<IEnumerable<int>> GetEquipmentsByTaskId(int taskId)
        {
            return await _context.EquipmentMaintenances
                .Where(em => em.MaintenanceTaskId == taskId)
                .Select(em => em.EquipmentId)
                .ToListAsync();
        }


        public async Task RemoveAllByTask(int taskId)
        {
            var existing = await _context.EquipmentMaintenances
                .Where(em => em.MaintenanceTaskId == taskId)
                .ToListAsync();
            
            _context.EquipmentMaintenances.RemoveRange(existing);
            _context.SaveChanges();

        }

        public async Task AddEquipmentsByTask(int taskId, IEnumerable<int> equipmentIds)
        {
            var newRelations = equipmentIds
               .Select(eid => new EquipmentMaintenance
               {
                   EquipmentId = eid,
                   MaintenanceTaskId = taskId
               });

            _context.EquipmentMaintenances.AddRange(newRelations);
            await _context.SaveChangesAsync();

        }


    }
}
