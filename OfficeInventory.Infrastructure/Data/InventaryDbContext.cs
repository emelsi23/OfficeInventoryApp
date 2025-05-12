using Microsoft.EntityFrameworkCore;
using OfficeInventory.Domain.Entities;

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

            modelBuilder.Entity<EquipmentType>().HasData(
             new EquipmentType { Id = 1, Description = "Laptop" },
             new EquipmentType { Id = 2, Description = "Desktop" },
             new EquipmentType { Id = 3, Description = "Printer" },
             new EquipmentType { Id = 4, Description = "Monitor" }
             );

        }
    }

}
