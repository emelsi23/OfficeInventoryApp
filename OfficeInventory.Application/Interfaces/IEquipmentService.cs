using OfficeInventory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Application.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetAllAsync();
        Task<EquipmentDto> GetByIdAsync(int id);
        Task<EquipmentDto> CreateAsync(EquipmentDto dto);
        Task<bool> UpdateAsync(int id, EquipmentDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<MaintenanceTaskDto>> GetMaintenancesByEquipmentIdAsync(int equipmentId);

    }
}
