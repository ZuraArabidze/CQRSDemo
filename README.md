# CQRS Custom Implementation

A clean CQRS implementation **without MediatR** to understand the core concepts.

## Architecture

- **Commands**: Write operations (Create, Update, Delete)
- **Queries**: Read operations (GetById, GetAll)
- **Custom Dispatchers**: Route commands/queries to handlers
- **PostgreSQL**: Single database for both reads and writes

## Project Structure
```
CqrsDemo.Custom/
├── Controllers/
│   └── ProductsController.cs
├── CQRS/
│   ├── Commands/
│   ├── Queries/
│   ├── Handlers/
│   │   ├── CommandHandlers/
│   │   └── QueryHandlers/
│   └── Infrastructure/
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Entities/
│   └── DTOs/
└── Program.cs
```

## Setup

### Prerequisites
- .NET 8.0 SDK
- PostgreSQL (or use Docker: `docker run --name postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres:15`)

### Steps

1. **Update connection string** in `appsettings.json`:
```csharp
"ConnwctionString" : "Host=localhost;Database=cqrs_demo;Username=postgres;Password=postgres";
```

2. **Run the application**:
```bash
cd CqrsDemo.Custom
dotnet run
```

3. **Open Swagger**:
Navigate to `https://localhost:5001/swagger`

## Testing

### Create a Product
```bash
curl -X POST https://localhost:5001/api/products/add \
  -H "Content-Type: application/json" \
  -d '{"name":"Laptop","price":999.99,"stock":10}'
```

### Get All Products
```bash
curl https://localhost:5001/api/products/all
```

## Key Concepts

### Command Pattern
Commands represent write operations and return a result (ID or success flag).

### Query Pattern
Queries represent read operations and return data (DTOs).

### Dispatchers
Custom dispatchers use dependency injection to resolve and execute the appropriate handler.

## Benefits of Custom Implementation

- Full control over dispatching logic
- No external dependencies
- Educational - understand CQRS internals
- Easy to debug and modify

## Next Steps

After understanding this implementation, check out:
- [`cqrs-mediatr` branch](../../tree/cqrs-mediatr) - See how MediatR simplifies this
- [`cqrs-event-driven` branch](../../tree/cqrs-event-driven) - Learn event-driven CQRS