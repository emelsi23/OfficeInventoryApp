using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeInventory.Domain.Entities;
using OfficeInventory.Infrastructure.Data;

namespace OfficeInventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypesController(InventaryDbContext context) : ControllerBase
    {

        private readonly InventaryDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentType>>> GetEquipmentTypes()
        {
            var types = await Task.FromResult(_context.EquipmentTypes.ToList());
            return Ok(types);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EquipmentType type)
        {
            _context.EquipmentTypes.Add(type);
            await _context.SaveChangesAsync();
            return Ok(type);
        }


    }
}
