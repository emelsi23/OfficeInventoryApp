using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;

namespace OfficeInventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentMaintenancesController(InventaryDbContext context) : ControllerBase
    {

        private readonly InventaryDbContext _context = context;

        [HttpPost("assign")]
        public async Task<IActionResult> AssignEquipments([FromBody] AssignEquipmentsDto model)
        {

            var existing = _context.EquipmentMaintenances
                .Where(em => em.MaintenanceTaskId == model.MaintenanceTaskId);
            _context.EquipmentMaintenances.RemoveRange(existing);

            var newRelations = model.EquipmentIds
                .Select(eid => new EquipmentMaintenance
                {
                    EquipmentId = eid,
                    MaintenanceTaskId = model.MaintenanceTaskId
                });

            _context.EquipmentMaintenances.AddRange(newRelations);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Equipments assigned successfully" });
        }

        [HttpGet("task/{taskId}")]
        public async Task<IActionResult> GetAssignedEquipments(int taskId)
        {
            var equipments = await _context.EquipmentMaintenances
                .Where(em => em.MaintenanceTaskId == taskId)
                .Select(em => em.EquipmentId)
                .ToListAsync();

            return Ok(equipments);
        }


    }
}
