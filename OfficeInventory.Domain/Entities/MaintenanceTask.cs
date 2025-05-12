namespace OfficeInventory.Domain.Entities
{
    public class MaintenanceTask
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public ICollection<EquipmentMaintenance>? EquipmentMaintenances { get; set; }
    }
}
