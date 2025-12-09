# CQRS with MediatR

Industry-standard CQRS implementation using the **MediatR** library.

## Architecture

- **MediatR**: Handles request/response pattern
- **Feature folders**: Organized by feature (Products)
- **Automatic handler registration**: No manual DI registration needed
- **PostgreSQL**: Database for both reads and writes

## Project Structure
```
CqrsDemo/
├── Controllers/
│   └── ProductsController.cs
├── Features/
│   └── Products/                      # Feature-based organization
│       ├── Commands/
│       │   ├── CreateProduct/
│       │   │   ├── CreateProductCommand.cs
│       │   │   └── CreateProductCommandHandler.cs
│       │   ├── UpdateProduct/
│       │   │   ├── UpdateProductCommand.cs
│       │   │   └── UpdateProductCommandHandler.cs
│       │   └── DeleteProduct/
│       │       ├── DeleteProductCommand.cs
│       │       └── DeleteProductCommandHandler.cs
│       └── Queries/
│           ├── GetProductById/
│           │   ├── GetProductByIdQuery.cs
│           │   └── GetProductByIdQueryHandler.cs
│           └── GetAllProducts/
│               ├── GetAllProductsQuery.cs
│               └── GetAllProductsQueryHandler.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Entities/
│   │   └── Product.cs
│   └── DTOs/
│       ├── ProductDto.cs
│       ├── CreateProductRequest.cs
│       └── UpdateProductRequest.cs
└── Program.cs
```

## Setup

### Prerequisites
- .NET 8.0 SDK
- PostgreSQL

### Steps

1. **Update connection string** in `Program.cs`

2. **Run**:
```bash
cd CqrsDemo
dotnet run
```

3. **Open Swagger**: `https://localhost:5001/swagger`

## Key MediatR Concepts

### IRequest<TResponse>
Marker interface for commands and queries:
```csharp
public class CreateProductCommand : IRequest<int> { }
```

### IRequestHandler<TRequest, TResponse>
Handler interface:
```csharp
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int> { }
```

### IMediator
Single interface to send all requests:
```csharp
var result = await _mediator.Send(command);
```

## Benefits of MediatR

- Industry standard
- Automatic handler registration
- Built-in pipeline behaviors
- Less boilerplate
- CancellationToken support

## Compare with Custom Implementation

See [`cqrs-custom` branch](../../tree/cqrs-custom) to compare with custom dispatchers.
