using OfficeInventory.Application.DTOs;

namespace OfficeInventory.Application.Interfaces
{
    public interface IMaintenanceTaskService
    {
        Task<IEnumerable<MaintenanceTaskDto>> GetAllAsync();
        Task<MaintenanceTaskDto> GetByIdAsync(int id);
        Task<MaintenanceTaskDto> CreateAsync(MaintenanceTaskDto dto);
        Task UpdateAsync(int id, MaintenanceTaskDto dto);
        Task DeleteAsync(int id);

    }
}
