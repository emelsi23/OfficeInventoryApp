using OfficeInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
