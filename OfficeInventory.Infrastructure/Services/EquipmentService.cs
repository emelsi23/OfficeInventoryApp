using FluentValidation;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Infrastructure.Services
{
    public class EquipmentService(IEquipmentRepository repo, IEquipmentMaintenanceRepository maintenanceRepo, IValidator<EquipmentDto> validator) : IEquipmentService
    {
        private readonly IEquipmentRepository _repo = repo;
        private readonly IEquipmentMaintenanceRepository _maintenanceRepo = maintenanceRepo;
        private readonly IValidator<EquipmentDto> _validator = validator;

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
            var equiment = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");
            return new EquipmentDto
            {
                Id = equiment.Id,
                Brand = equiment.Brand,
                Model = equiment.Model,
                EquipmentTypeId = equiment.EquipmentTypeId,
                PurchaseDate = equiment.PurchaseDate,
                SerialNumber = equiment.SerialNumber
            };
        }

        public async Task<EquipmentDto> CreateAsync(EquipmentDto dto)
        {
            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage);
                var errosMessages = string.Join(", ", errors);

                throw new InvalidOperationException(errosMessages);
            }

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

        public async Task UpdateAsync(int id, EquipmentDto dto)
        {
            var entity = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");


            entity.Brand = dto.Brand;
            entity.Model = dto.Model;
            entity.EquipmentTypeId = dto.EquipmentTypeId;
            entity.PurchaseDate = dto.PurchaseDate;
            entity.SerialNumber = dto.SerialNumber;

            _repo.Update(entity);
            await _repo.SaveAsync();
       
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");

            _repo.Remove(entity);
            await _repo.SaveAsync();
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
