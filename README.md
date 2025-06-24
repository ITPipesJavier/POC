## 🏗️ Modular Monolithic Architecture (Clean Architecture + DDD)

This project follows a **modular monolith** architecture using **Domain-Driven Design (DDD)** and **Clean Architecture** principles to ensure:

- ✅ High maintainability  
- ✅ Separation of concerns  
- ✅ Full testability (unit + integration)  
- ✅ Shared logic across desktop, web, and mobile  
- ✅ Safe deployments with isolated modules  
- ✅ Clear migration path to microservices if needed  

### 📦 Solution Structure
ITpipes.sln
├── Connect # Desktop app (WPF)

├── Web # Web app (ASP.NET)

├── Mobile # Optional mobile client

├── Domain # Shared entities, enums, value objects

├── Logic.Core # Business logic and domain services

├── Logic.Admin # Admin-specific logic

├── Repository # Persistence (SQL Server, SQLite)

├── Storage # File/blob storage interfaces + adapters

├── Integration # External APIs (GIS, Cityworks)

├── Repository.UnitTests # Unit tests

├── Repository.IntegrationTests# Integration tests


### 🧪 Testing

- `Repository.UnitTests`: Fast unit testing with mocks  
- `Repository.IntegrationTests`: Real DB testing (SQL Server, SQLite)  
- Flyway support for database versioning  

### 🐘 Database Versioning

This repo uses **Flyway** for schema migrations:

- Works with **SQL Server** (production) and **SQLite** (testing)
- Migrations tracked in `/Database/Flyway/sql`
- Supports CI/CD and local development environments

### 🐳 Containerization & CI

The architecture is built on **.NET 6+** to support:

- Lightweight Docker containers  
- Faster CI pipelines  
- Cross-platform development

