using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Infrastructure.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repo;
        private readonly IEquipmentMaintenanceRepository _maintenanceRepo;

        public EquipmentService(IEquipmentRepository repo, IEquipmentMaintenanceRepository maintenanceRepo)
        {
            _repo = repo;
            _maintenanceRepo = maintenanceRepo;
        }

        public async Task<IEnumerable<EquipmentDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(e => new EquipmentDto
            {
                Id = e.Id,
                Brand = e.Brand,
                Model = e.Model,
                EquipmentTypeId = e.EquipmentTypeId,
                PurchaseDate = e.PurchaseDate,
                SerialNumber = e.SerialNumber
            });
        }

        public async Task<EquipmentDto> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;

            return new EquipmentDto
            {
                Id = e.Id,
                Brand = e.Brand,
                Model = e.Model,
                EquipmentTypeId = e.EquipmentTypeId,
                PurchaseDate = e.PurchaseDate,
                SerialNumber = e.SerialNumber
            };
        }

        public async Task<EquipmentDto> CreateAsync(EquipmentDto dto)
        {
            var entity = new Equipment
            {
                Brand = dto.Brand,
                Model = dto.Model,
                EquipmentTypeId = dto.EquipmentTypeId,
                PurchaseDate = dto.PurchaseDate,
                SerialNumber = dto.SerialNumber
            };

            await _repo.AddAsync(entity);
            await _repo.SaveAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, EquipmentDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.Brand = dto.Brand;
            entity.Model = dto.Model;
            entity.EquipmentTypeId = dto.EquipmentTypeId;
            entity.PurchaseDate = dto.PurchaseDate;
            entity.SerialNumber = dto.SerialNumber;

            _repo.Update(entity);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            _repo.Remove(entity);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<MaintenanceTaskDto>> GetMaintenancesByEquipmentIdAsync(int equipmentId)
        {
            var tasks = await _maintenanceRepo.GetTasksByEquipmentIdAsync(equipmentId);
            return tasks.Select(t => new MaintenanceTaskDto
            {
                Id = t.Id,
                Description = t.Description
            });
        }
    }
}
