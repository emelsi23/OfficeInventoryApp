using System.Text.Json.Serialization;

namespace OfficeInventory.Domain.Entities
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Equipment>? Equipments { get; set; }
    }
}
