using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Repositories;

namespace OfficeInventory.Infrastructure.Services
{
    public class MaintenanceTaskService : IMaintenanceTaskService
    {
        private readonly IMaintenanceTaskRepository _repo;
        private readonly IEquipmentMaintenanceRepository _maintenanceRepo;
        private readonly IValidator<MaintenanceTaskDto> _validator;

        public MaintenanceTaskService(IMaintenanceTaskRepository repo, IValidator<MaintenanceTaskDto> validator, IEquipmentMaintenanceRepository maintenanceRepo)
        {
            _repo = repo;
            _validator = validator;
            _maintenanceRepo = maintenanceRepo;

        }

        public async Task<IEnumerable<MaintenanceTaskDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(e => new MaintenanceTaskDto
            {
                Id = e.Id,
                Description = e.Description
            });
        }

        public async Task<MaintenanceTaskDto> GetByIdAsync(int id)
        {
            var maintenance = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");
            return new MaintenanceTaskDto
            {
                Id = maintenance.Id,
                Description = maintenance.Description

            };
        }

        public async Task<MaintenanceTaskDto> CreateAsync(MaintenanceTaskDto dto)
        {
            var result = await _validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage);
                var errosMessages = string.Join(", ", errors);

                throw new InvalidOperationException(errosMessages);
            }

            var entity = new MaintenanceTask
            {
                Description = dto.Description
            };

            await _repo.AddAsync(entity);
            await _repo.SaveAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task UpdateAsync(int id, MaintenanceTaskDto dto)
        {
            var entity = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");
            entity.Description = dto.Description;
            _repo.Update(entity);
            await _repo.SaveAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id) ?? throw new ArgumentException("Entity not found");

            _repo.Remove(entity);
            await _repo.SaveAsync();
        }


         public async Task<IEnumerable<int>> GetEquipmentsByTaskId(int taskId)
        {
            var equipments = await _maintenanceRepo.GetEquipmentsByTaskId(taskId);

            return equipments;
        }


        public async Task AssignEquipmentsBy(AssignEquipmentsDto model)
        {

             await _maintenanceRepo.RemoveAllByTask(model.MaintenanceTaskId);

            await _maintenanceRepo.AddEquipmentsByTask(model.MaintenanceTaskId, model.EquipmentIds);

        }
    }
}
