CREATE DATABASE OfficeInventoryDb
GO

USE OfficeInventoryDb
GO

CREATE TABLE [EquipmentTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_EquipmentTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
  INSERT INTO EquipmentTypes (Description)
  values ('Laptop'), ('Desktop'), ('Printer'), ('Monitor')
GO

CREATE TABLE [MaintenanceTasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_MaintenanceTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Equipments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[EquipmentTypeId] [int] NOT NULL,
	[PurchaseDate] [datetime2](7) NOT NULL,
	[SerialNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Equipments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Equipments]  WITH CHECK ADD  CONSTRAINT [FK_Equipments_EquipmentTypes_EquipmentTypeId] FOREIGN KEY([EquipmentTypeId])
REFERENCES [EquipmentTypes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [Equipments] CHECK CONSTRAINT [FK_Equipments_EquipmentTypes_EquipmentTypeId]
GO

CREATE TABLE [EquipmentMaintenances](
	[EquipmentId] [int] NOT NULL,
	[MaintenanceTaskId] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentMaintenances] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC,
	[MaintenanceTaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [EquipmentMaintenances]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentMaintenances_Equipments_EquipmentId] FOREIGN KEY([EquipmentId])
REFERENCES [Equipments] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [EquipmentMaintenances] CHECK CONSTRAINT [FK_EquipmentMaintenances_Equipments_EquipmentId]
GO

ALTER TABLE [EquipmentMaintenances]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentMaintenances_MaintenanceTasks_MaintenanceTaskId] FOREIGN KEY([MaintenanceTaskId])
REFERENCES [MaintenanceTasks] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [EquipmentMaintenances] CHECK CONSTRAINT [FK_EquipmentMaintenances_MaintenanceTasks_MaintenanceTaskId]
GO

