using OfficeInventory.Domain.Entities;

namespace OfficeInventory.Application.Interfaces
{
    public interface IEquipmentMaintenanceRepository
    {
        Task<IEnumerable<MaintenanceTask>> GetTasksByEquipmentIdAsync(int equipmentId);
        Task<IEnumerable<Equipment>> GetEquipmentsByTaskId(int taskId);

    }
}
