using OfficeInventory.Domain.Entities;

namespace OfficeInventory.Application.Interfaces
{
    public interface IEquipmentMaintenanceRepository
    {
        Task<IEnumerable<MaintenanceTask>> GetTasksByEquipmentIdAsync(int equipmentId);
        Task<IEnumerable<int>> GetEquipmentsByTaskId(int taskId);
        Task RemoveAllByTask(int taskId);
        Task AddEquipmentsByTask(int taskId, IEnumerable<int> equipmentIds);


    }
}
