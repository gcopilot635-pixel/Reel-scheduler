# ReelSchedulerPro Setup Guide

## Prerequisites
- .NET 8 SDK
- PostgreSQL 14+
- Visual Studio 2022 or VS Code

## Installation Steps

### 1. Clone Repository
```bash
git clone https://github.com/gcopilot635-pixel/Reel-scheduler.git
cd Reel-scheduler
```

### 2. Setup Database

#### Using Docker
```bash
docker run --name reelschedulerpro-db -e POSTGRES_PASSWORD=postgres -d -p 5432:5432 postgres:14
```

#### Using Local PostgreSQL
Update `appsettings.json` with your connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=your-host;Database=ReelSchedulerPro;Username=your-user;Password=your-password"
}
```

### 3. Apply Database Migrations

#### From Visual Studio
```powershell
Update-Database
```

#### From Command Line
```bash
dotnet ef database update --project src/ReelSchedulerPro.Infrastructure --startup-project src/ReelSchedulerPro.Api
```

### 4. Run the Application

```bash
# Terminal 1: API
cd src/ReelSchedulerPro.Api
dotnet run

# Terminal 2: Worker
cd src/ReelSchedulerPro.Worker
dotnet run
```

## Project Structure

```
ReelSchedulerPro/
├── src/
│   ├── ReelSchedulerPro.Api/           # ASP.NET Core Web API
│   ├── ReelSchedulerPro.Application/   # Business Logic (CQRS)
│   ├── ReelSchedulerPro.Domain/        # Domain Entities
│   ├── ReelSchedulerPro.Infrastructure # Data Access, Services
│   ├── ReelSchedulerPro.Worker/        # Background Jobs
│   └── ReelSchedulerPro.Shared/        # DTOs, Constants
├── ReelSchedulerPro.sln
├── appsettings.json
├── .gitignore
└── README.md
```

## API Endpoints

### Authentication
- `POST /api/auth/login` - Login
- `POST /api/auth/refresh` - Refresh Token

### Scheduler
- `POST /api/scheduler/schedule-reel` - Schedule a reel
- `GET /api/scheduler/reels` - Get scheduled reels

## Configuration

Update `appsettings.json` with your settings:

```json
{
  "JwtSettings": {
    "Secret": "your-strong-secret-key",
    "Issuer": "ReelSchedulerPro",
    "Audience": "ReelSchedulerPro",
    "ExpirationMinutes": 60
  },
  "Instagram": {
    "ApiUrl": "https://graph.instagram.com",
    "ApiVersion": "v18.0"
  }
}
```

## Development

### Building
```bash
dotnet build
```

### Running Tests (when added)
```bash
dotnet test
```

### Code Generation
```bash
# Create a new migration
dotnet ef migrations add MigrationName --project src/ReelSchedulerPro.Infrastructure --startup-project src/ReelSchedulerPro.Api
```

## Security Considerations

1. **Environment Variables**: Never commit sensitive data
2. **Token Encryption**: Access tokens are encrypted in database
3. **Input Validation**: FluentValidation is used for all inputs
4. **Rate Limiting**: Implement rate limiting for production
5. **CORS**: Configure CORS appropriately for production

## Troubleshooting

### Connection String Issues
Verify PostgreSQL is running and accessible:
```bash
psql -U postgres -h localhost
```

### Migration Errors
Clear and reapply migrations:
```bash
dotnet ef database drop --project src/ReelSchedulerPro.Infrastructure --startup-project src/ReelSchedulerPro.Api
dotnet ef database update --project src/ReelSchedulerPro.Infrastructure --startup-project src/ReelSchedulerPro.Api
```

## Next Steps

1. Implement JWT authentication in AuthenticationService
2. Create Instagram API integration
3. Implement AI Caption generation
4. Add comprehensive error handling
5. Create unit tests
6. Build React frontend

## Support

For issues, please create an GitHub issue in the repository.
