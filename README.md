# StratoFlow

A modern .NET 8 web API built with ASP.NET Core, featuring a clean architecture design with separation of concerns.

## Overview

StratoFlow is a RESTful API application that provides user management functionality with a modular architecture. The solution is organized into separate projects for API endpoints and core business logic.

## Architecture

- **StratoFlow.API** - Web API layer containing controllers and API configuration
- **StratoFlow.Core** - Core business logic, models, and domain entities

## Features

- RESTful API endpoints
- User management system with role-based access
- Three distinct user roles: Admin, User, and Guest
- Swagger/OpenAPI documentation
- Clean architecture with separation of concerns
- Built on .NET 8 framework (migrated from .NET 9 for enhanced stability and LTS support)
- Demo-ready with predefined user accounts for different scenarios
## Getting Started

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or VS Code

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Build the solution:
   ```
   dotnet build
   ```
4. Run the API:
   ```
   dotnet run --project StratoFlow.API
   ```

The API will be available at `https://localhost:7066` or `http://localhost:5105`.

### API Documentation

When running in development mode, Swagger UI is available at `/swagger` for interactive API documentation and testing.

## API Endpoints

### User Management
- `GET /api/users` - Retrieve all users
- `GET /api/users/{id}` - Get specific user by ID  
- `GET /api/users/username/{username}` - Get user by username
- `GET /api/users/role/{role}` - Get users filtered by role (Admin, User, Guest)
- `GET /api/users/demo-credentials` - Get demo account information

### Demo User Roles
- **Admin** (`admin`) - Full system access for testing and maintenance
- **User** (`jsmith`) - Standard user credentials for project demonstrations  
- **Guest** (`guest`) - Limited access for hiring managers to explore the application

## Technology Stack

- .NET 8 (Long Term Support - migrated from .NET 9)
- ASP.NET Core Web API
- Swagger/OpenAPI
- Entity Framework Core ready architecture

## Migration Notes

This project was initially developed on .NET 9 and has been migrated to .NET 8 to leverage:
- **Long Term Support (LTS)** - .NET 8 is an LTS release with 3 years of support
- **Enterprise Stability** - Better suited for production environments
- **Broader Ecosystem Compatibility** - More third-party libraries and tools support .NET 8

## Project Structure

```
StratoFlow/
├── StratoFlow.API/         # Web API project
│   ├── Controllers/        # API controllers
│   ├── Program.cs          # Application entry point
│   └── appsettings.json    # Configuration
├── StratoFlow.Core/        # Core business logic
│   └── Models/             # Domain models
└── StratoFlow.sln          # Solution file
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
