using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
