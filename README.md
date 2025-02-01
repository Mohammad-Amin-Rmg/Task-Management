# Task Management System 🚀  
**A modern task management web app built with ASP.NET Core Razor Pages, Entity Framework Core, and SQL Server (Using TPH Inheritance for each task type).**

## Features ✨  
- **Task Management**: CRUD, Kanban Board, Search, User-Task Assignments  
- **User Management**: CRUD for users
- **Project Management**: Assign task to a project  
- **Tech Stack**: ASP.NET Core Razor Pages, EF Core, Bootstrap  

## Installation ⚙️  
1. **Clone the repository**:  
   ```bash
   git clone https://github.com/Mohammad-Amin-Rmg/Task-Management 
2. **Create Database**:
   Install EF Core CLI tools (if missing):  
   ```bash
   dotnet tool install --global dotnet-ef
3. **Run migrations**:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
4. **Run the app**:
   ```bash
   dotnet run
