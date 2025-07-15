## Package content

This package contains common functionality used across multiple projects, including:

### Models

- `BaseEntity`: A base class for entities with an `Id`, `CreatedAt`, `UpdatedAt`, and `DeletedAt` properties.
- `BlamingEntity`: An extension of `BaseEntity` that includes `CreatedBy`, `UpdatedBy` and `DeletedBy` properties for tracking user actions.

### Extensions
- `SerilogExtensions`: Provides methods to configure Serilog for logging.

### Interfaces
- `IHashingService`: An interface for hashing services.
- `IRepository`: A generic repository interface for CRUD operations.

### Middleware
- `ExceptionLoggingMiddleware`: Generic middleware for logging exceptions.
- `RequestLoggingMiddleware`: Middleware for logging HTTP requests.

### Services
- `HashingService`: A service that implements `IHashingService` for hashing strings.

### Utils
- `DotenvLoader`: A utility for loading environment variables from a `.env` file.

## How to use

Include the following file in the root of your project `NuGet.Config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/k-vandijk/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="k-vandijk" />
      <add key="ClearTextPassword" value="GITHUB_PAT" />
    </github>
  </packageSourceCredentials>
</configuration>
```

Then you can install the package using 

```terminal
dotnet add package kvandijk.Common
```

Configure *logging*, *middleware* and *environment variables* in `Program.cs` using

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
