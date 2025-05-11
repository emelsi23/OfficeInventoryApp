
Office Inventory API

A RESTful API for managing office equipment and maintenance tasks. Built with ASP.NET Core 8.0, Entity Framework Core, and FluentValidation. Designed to integrate with a Vue.js 3 frontend.

---

Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- FluentValidation
- Swagger / OpenAPI
- CORS
- Clean Architecture (layered structure)

---

Project Structure

OfficeInventory/
├── Application/               # Interfaces, DTOs, and validators
├── Domain/                    # Domain entities
├── Infrastructure/            # Repositories, services, and DbContext
├── WebAPI/                    # Controllers, configuration, and entry point
│   └── DependencyInjection/   # Service registration (dependency injection)

---

🚀 Getting Started

1. Clone the repository

git clone https://github.com/yourusername/OfficeInventory.git
cd OfficeInventory

2. Configure the connection string

Edit the `appsettings.json` file inside `OfficeInventoryApp`:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OfficeInventoryDb;Trusted_Connection=True;"
  }
}

3. Restore NuGet packages

dotnet restore

4. Apply migrations and create the database

dotnet ef database update

(To create a new migration)
dotnet ef migrations add InitialCreate

5. Run the application

dotnet run --project OfficeInventoryApp

---

📬 Main Endpoints

| Method | Endpoint               | Description                             |
|--------|------------------------|-----------------------------------------|
| GET    | /api/equipment         | Get all equipment                       |
| GET    | /api/equipment/{id}    | Get equipment by ID                     |
| POST   | /api/equipment         | Create new equipment                    |
| PUT    | /api/equipment/{id}    | Update equipment                        |
| DELETE | /api/equipment/{id}    | Delete equipment                        |
| GET    | /api/maintenance       | Get maintenance tasks                   |
| POST   | /api/maintenance       | Create new maintenance task             |

All endpoints are documented via Swagger.

---

Validation

FluentValidation is used to enforce business rules on DTOs like EquipmentDto and MaintenanceTaskDto, ensuring data quality at the input layer.

---

CORS Enabled

Allows requests from the Vue.js frontend located at:
http://localhost:5173

---

✍️ Author

Victor E. Sánchez Garcia
.NET & Vue.js Developer

