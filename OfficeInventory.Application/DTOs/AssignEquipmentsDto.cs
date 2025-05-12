namespace OfficeInventory.Application.DTOs
{
    public class AssignEquipmentsDto
    {
        public int MaintenanceTaskId { get; set; }
        public List<int>? EquipmentIds { get; set; }
    }
}
