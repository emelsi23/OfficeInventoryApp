using Microsoft.AspNetCore.Mvc;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;

namespace OfficeInventoryApp.Controllers
{
    [ApiController]
    [Route("api/equipment")]
    public class EquipmentController(IEquipmentService service) : ControllerBase
    {
        private readonly IEquipmentService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EquipmentDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{equipmentId}/maintenances")]
        public async Task<IActionResult> GetMaintenancesByEquipment(int equipmentId)
        {
            var result = await _service.GetMaintenancesByEquipmentIdAsync(equipmentId);
            return Ok(result);
        }
    }
}
