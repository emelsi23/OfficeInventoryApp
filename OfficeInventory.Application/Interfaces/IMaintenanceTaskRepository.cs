using OfficeInventory.Domain.Entities;

namespace OfficeInventory.Application.Interfaces
{
    public interface IMaintenanceTaskRepository
    {
        Task<IEnumerable<MaintenanceTask>> GetAllAsync();
        Task<MaintenanceTask> GetByIdAsync(int id);
        Task AddAsync(MaintenanceTask entity);
        void Update(MaintenanceTask entity);
        void Remove(MaintenanceTask entity);
        Task SaveAsync();

    }
}
