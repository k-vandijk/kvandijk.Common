## Package content

This package contains common functionality used across multiple projects, including:

### BackgroundTasks

- `BackgroundTaskQueue`: A thread-safe queue for managing background tasks.
- `IBackgroundTaskQueue`: An interface for the background task queue.
- `QueuedWorker`: A hosted service that processes tasks from the `BackgroundTaskQueue`.

### Diagnostics

- `RequestTimingMiddleware`: Middleware for measuring and logging the time taken to process HTTP requests.
- `SkipRequestTimingAttribute`: An attribute to skip request timing for specific endpoints.

### Entities

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

### wwwroot
- `top-loading-bar.css`: A CSS file for a top loading bar UI component.
- `top-loading-bar.js`: A JavaScript file for a top loading bar UI component.

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
app.UseMiddleware<RequestTimingMiddleware>();

...
```

Configure background tasks in `Program.cs` using
```c
using kvandijk.Common.BackgroundTasks;

...

services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
services.AddHostedService<QueuedWorker>();
```