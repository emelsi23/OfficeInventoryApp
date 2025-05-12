using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;

namespace OfficeInventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentMaintenancesController(IMaintenanceTaskService _maintenanceService) : ControllerBase
    {


        [HttpPost("assign")]
        public async Task<IActionResult> AssignEquipments([FromBody] AssignEquipmentsDto model)
        {

            await _maintenanceService.AssignEquipmentsBy(model);
            return Ok(new { message = "Equipments assigned successfully" });
        }

        [HttpGet("task/{taskId}/equipments")]
        public async Task<IActionResult> GetAssignedEquipments(int taskId)
        {
            var equipments = await _maintenanceService.GetEquipmentsByTaskId(taskId);
        
            return Ok(equipments);
        }


    }
}
