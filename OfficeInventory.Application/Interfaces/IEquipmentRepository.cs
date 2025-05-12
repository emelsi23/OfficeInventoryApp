using OfficeInventory.Domain.Entities;

namespace OfficeInventory.Application.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment> GetByIdAsync(int id);
        Task AddAsync(Equipment entity);
        void Update(Equipment entity);
        void Remove(Equipment entity);
        Task SaveAsync();

    }
}
