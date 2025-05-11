using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeInventory.Domain.Entities;
using System.Threading.Tasks;

namespace OfficeInventory.Infrastructure.Data
{
    public class InventaryDbContext(DbContextOptions<InventaryDbContext> options) : DbContext(options)
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        public DbSet<EquipmentMaintenance> EquipmentMaintenances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentMaintenance>()
                .HasKey(em => new { em.EquipmentId, em.MaintenanceTaskId });

            base.OnModelCreating(modelBuilder);

        }
    }

}
