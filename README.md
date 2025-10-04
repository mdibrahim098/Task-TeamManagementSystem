# 🧾 Task & Team Management System

## 📋 Overview
The **Task & Team Management System** is a modular application built with **.NET Core** and **Entity Framework Core**.  
It allows organizations to manage teams, assign tasks, and monitor progress efficiently.  
The project follows **Clean Architecture** principles — ensuring separation of concerns, maintainability, and testability.

---

## 🏗️ Architecture
This project is structured following **Clean Architecture**:

```
src/
├── Application      → Business logic layer (CQRS, MediatR, validation)
├── Domain           → Entities, value objects, domain events, exceptions
├── Infrastructure   → EF Core, database configurations, repositories
├── WebApi (or UI)   → API endpoints or MVC UI, dependency injection
```

**Key Principles:**
- Domain layer is independent of frameworks.
- Application layer defines business use cases.
- Infrastructure handles persistence and external services.
- Presentation layer interacts with users or clients.

---

## ⚙️ Technologies Used
| Category | Technology |
|-----------|-------------|
| Framework | .NET 8 / .NET 7 |
| ORM | Entity Framework Core |
| Architecture | Clean Architecture, DDD principles |
| Pattern | CQRS, MediatR, Repository Pattern |
| Database | SQL Server |
| Dependency Injection | Built-in .NET DI Container |
| Validation | FluentValidation (optional) |
| Logging | Serilog (optional) |
| API Docs | Swagger |



### 🔧 Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code


## 👥 Features
- Manage teams and members  
- Create and assign tasks  
- Track task progress and deadlines  
- Domain event logging  
- Strongly typed IDs using Value Objects  
- EF Core entity configurations  
- Unique indexes and validation


