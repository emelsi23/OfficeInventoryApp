using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Infrastructure.Repositories
{
    public class EquipmentMaintenanceRepository : IEquipmentMaintenanceRepository
    {
        private readonly InventaryDbContext _context;

        public EquipmentMaintenanceRepository(InventaryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceTask>> GetTasksByEquipmentIdAsync(int equipmentId)
        {
            return await _context.EquipmentMaintenances
                .Where(em => em.EquipmentId == equipmentId)
                .Select(em => em.MaintenanceTask)
                .ToListAsync();
        }
    }
}
