using OfficeInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Application.Interfaces
{
    public interface IEquipmentMaintenanceRepository 
    {
        Task<IEnumerable<MaintenanceTask>> GetTasksByEquipmentIdAsync(int equipmentId);
        Task<IEnumerable<Equipment>> GetEquipmentsByTaskId(int taskId);

    }
}
