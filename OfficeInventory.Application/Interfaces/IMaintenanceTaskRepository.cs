using OfficeInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
