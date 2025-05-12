using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;

namespace OfficeInventory.Infrastructure.Repositories
{
    public class EquipmentRepository(InventaryDbContext context) : IEquipmentRepository
    {

        private readonly InventaryDbContext _context = context;

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            return await _context.Equipments.FindAsync(id);
        }

        public async Task AddAsync(Equipment entity)
        {
            await _context.Equipments.AddAsync(entity);
        }

        public void Update(Equipment entity)
        {
            _context.Equipments.Update(entity);
        }

        public void Remove(Equipment entity)
        {
            _context.Equipments.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
