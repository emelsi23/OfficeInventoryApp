using OfficeInventory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
