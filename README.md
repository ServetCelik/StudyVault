# 📘 StudyVault

A full-stack knowledge management system for storing and searching study notes.  
Built with **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **Azure AI Search**.

---

## 🚀 Features

- ✍️ Create study notes with title, content, tags, subject, and difficulty
- 🔍 Full-text search powered by Azure AI Search
- 📂 Filter by subject, difficulty, tags, and author name
- 📄 Paginated search results with total count
- 🧠 Clean Architecture with separation of concerns
- ⚙️ EF Core for database interaction and migrations
- 🐳 Docker-based SQL Server for local development

---

## 📁 Project Structure

```
StudyVault.sln
├── StudyVault.API           # ASP.NET Core Web API (entry point)
├── StudyVault.Application   # Use cases, DTOs, interfaces
├── StudyVault.Domain        # Core business entities and rules
└── StudyVault.Infrastructure# EF Core, DbContext, Azure Search integration
```

---

## 🛠️ Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (via Docker)
- Azure AI Search with full-text, filters, and pagination
- Clean Architecture principles

---

## 🐳 Getting Started (with Docker)

### 1. Run SQL Server in Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Password1" -p 1433:1433 --name studyvault-sql -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Configure the connection string

In `StudyVault.API/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=StudyVaultDb;User Id=sa;Password=YourStrong@Password1;TrustServerCertificate=True;"
}
```

🔒 **Note**: This password and config are for local development only. Never commit production secrets.

### 3. Apply the database migrations

```bash
dotnet ef migrations add InitialCreate --project StudyVault.Infrastructure --startup-project StudyVault.API
dotnet ef database update --project StudyVault.Infrastructure --startup-project StudyVault.API
```

### 4. Run the application

```bash
dotnet run --project StudyVault.API
```

Open Swagger UI (dev only):  
➡️ https://localhost:5001/swagger

---

## 📦 Search API

### 🔎 Full-Text Search with Filters and Pagination

**Endpoint**  
```
GET /api/search
```

**Query Parameters:**

- `q` *(optional)* — Full-text search term (defaults to all documents)
- `subject` *(optional)* — Filter by subject (e.g. "CS", "Math")
- `difficulty` *(optional)* — Filter by difficulty level
- `tag` *(optional)* — Filter by matching tag
- `authorName` *(optional)* — Filter by author name
- `page` *(optional)* — Page number (default: 1)
- `pageSize` *(optional)* — Results per page (default: 10)

**Example Request**

```
GET /api/search?q=graph&subject=CS&difficulty=Intermediate&page=2&pageSize=5
```

**Response Structure**

```json
{
  "totalCount": 86,
  "page": 2,
  "pageSize": 5,
  "results": [
    {
      "id": "57a1e7c4-91c1-4ea5-a374-2e540d045b3e",
      "title": "Binary Search Trees Explained",
      "summary": "Quick intro to BSTs and traversal methods",
      "subject": "CS",
      "tags": ["tree", "search", "binary"],
      "difficulty": "Intermediate",
      "createdAt": "2024-12-01T10:45:00"
    }
  ]
}
```

✅ This structure supports frontend pagination, infinite scroll, and UI filtering.

---

## 📌 Roadmap

- ✅ Create study note entity and service  
- ✅ Add SQL Server with EF Core  
- ✅ Add Azure AI Search integration  
- ✅ Add search filters and pagination  
- ⬜ Add scoring profiles  
- ⬜ Build minimal frontend (React or Blazor)

---

## 🤝 Contributing

This is a personal portfolio project — but feel free to fork, suggest improvements, or use the structure for your own learning!

---

## 📄 License

MIT

---

## ✨ Author

Created by **S. Celik** — software engineer passionate about backend architecture and search technologies.
