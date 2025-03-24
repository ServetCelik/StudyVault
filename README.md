# 📘 StudyVault

A full-stack knowledge management system for storing and searching study notes.  
Built with **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **Azure AI Search**.

---

## 🚀 Features

- ✍️ Create study notes with title, content, tags, subject, and difficulty
- 🔍 Full-text search powered by Azure AI Search
- 📂 Filter by subject, difficulty, tags
- 🧠 Clean Architecture with separation of concerns
- ⚙️ EF Core for database interaction and migrations
- 🐳 Docker-based SQL Server for local development

---

## 📁 Project Structure

StudyVault.sln ├── StudyVault.API ├── StudyVault.Application ├── StudyVault.Domain └── StudyVault.Infrastructure


- **StudyVault.API** – Entry point with ASP.NET Core controllers and DI config  
- **StudyVault.Application** – Use case interfaces, DTOs, and business logic orchestration  
- **StudyVault.Domain** – Business entities and validation logic (pure C#)  
- **StudyVault.Infrastructure** – EF Core, DbContext, Azure Search integration

---

## 🛠️ Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (via Docker)
- Azure AI Search *(to be integrated soon)*
- Clean Architecture principles

---

## 🐳 Getting Started (with Docker)

### 1. Run SQL Server in Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Password1" -p 1433:1433 --name studyvault-sql -d mcr.microsoft.com/mssql/server:2022-latest

2. Configure the connection string

In StudyVault.API/appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=StudyVaultDb;User Id=sa;Password=YourStrong@Password1;TrustServerCertificate=True;"
}

    🔒 Note: This password and config are for local development only. Never commit production secrets.

3. Apply the database migrations

dotnet ef database update --project StudyVault.Infrastructure --startup-project StudyVault.API

🧪 Run the Application

From the root folder:

dotnet run --project StudyVault.API

Open Swagger UI (dev only):
➡️ https://localhost:5001/swagger
📌 Roadmap

Create study note entity and service

Add SQL Server with EF Core

Add Azure AI Search integration

Add search filters and scoring profiles

    Build minimal frontend (React)

🤝 Contributing

This is a personal portfolio project — but feel free to fork, suggest improvements, or use the structure for your own learning!
📄 License

MIT
✨ Author

Created by S.Celik — software engineer passionate about backend architecture and search technologies.
