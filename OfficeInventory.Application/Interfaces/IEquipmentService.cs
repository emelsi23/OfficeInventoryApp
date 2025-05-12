using OfficeInventory.Application.DTOs;

namespace OfficeInventory.Application.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetAllAsync();
        Task<EquipmentDto> GetByIdAsync(int id);
        Task<EquipmentDto> CreateAsync(EquipmentDto dto);
        Task UpdateAsync(int id, EquipmentDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<MaintenanceTaskDto>> GetMaintenancesByEquipmentIdAsync(int id);

    }
}
