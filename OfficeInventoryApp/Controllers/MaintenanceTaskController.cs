using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeInventory.Application.DTOs;
using OfficeInventory.Application.Interfaces;

namespace OfficeInventoryApp.Controllers
{
    [ApiController]
    [Route("api/maintenancetasks")]
    public class MaintenanceTasksController(IMaintenanceTaskService service) : ControllerBase
    {
        private readonly IMaintenanceTaskService _service = service;

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
        public async Task<IActionResult> Create([FromBody] MaintenanceTaskDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceTaskDto dto)
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
    }
}
