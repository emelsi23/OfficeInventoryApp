using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeInventory.Application.DTOs
{
   public class AssignEquipmentsDto
    {
        public int MaintenanceTaskId { get; set; }
        public List<int>? EquipmentIds { get; set; }
    }
}
