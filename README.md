## Package content

This package contains common functionality used across multiple projects, including:

### Models

- `BaseEntity`: A base class for entities with an `Id`, `CreatedAt`, `UpdatedAt`, and `DeletedAt` properties.
- `BlamingEntity`: An extension of `BaseEntity` that includes `CreatedBy`, `UpdatedBy` and `DeletedBy` properties for tracking user actions.

### Exceptions

- `ChatCompletionException`: Exceptions that are used by the ChatCompletionService.

### Extensions

- `ChatCompletionExtensions`: Provides methods to configure the ChatCompletionService.
- `SerilogExtensions`: Provides methods to configure Serilog for logging.

### Interfaces

- `IChatCompletionService`: An interface for the ChatCompletionService.
- `IHashingService`: An interface for hashing services.
- `IRepository`: A generic repository interface for CRUD operations.

### Middleware
- `ExceptionLoggingMiddleware`: Generic middleware for logging exceptions.
- `RequestLoggingMiddleware`: Middleware for logging HTTP requests.

### Services

- `ChatCompletionService`: A service that handles requests to the azure openai api in a more developer-friendly way.
- `HashingService`: A service that implements `IHashingService` for hashing strings.

### Utils
- `DotenvLoader`: A utility for loading environment variables from a `.env` file.

## How to use

Install the package using:

```terminal
dotnet add package kvandijk.Common
```

Configure *logging*, *exception handling* and *environment variables* in `Program.cs` using

```c#
using kvandijk.Common.Logging;
using kvandijk.Common.Middleware;
...

// Load environment variables
DotenvLoader.Load();

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
builder.ConfigureSerilog();

...

var app = builder.Build();

// Middleware pipeline configuration
app.UseMiddleware<ExceptionLoggingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

...
```
