namespace OfficeInventory.Domain.Entities
{
    public class EquipmentMaintenance
    {
        public int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public int MaintenanceTaskId { get; set; }
        public MaintenanceTask? MaintenanceTask { get; set; }

    }
}
