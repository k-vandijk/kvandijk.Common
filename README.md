
## How to contribute

To publish a new release, build using 

```terminal
dotnet build -c Release
```

Then publish using

```terminal
dotnet nuget push bin/Release/kvandijk.Common.1.0.0.nupkg --source "github" --api-key YOUR_GITHUB_PAT
```

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
      <add key="ClearTextPassword" value="YOUR_GITHUB_PAT" />
    </github>
  </packageSourceCredentials>
</configuration>
```

Then, you can install the package using 

```terminal
dotnet add package kvandijk.Common
```

Configure *logging*, *middleware* and *environment variables* in `Program.cs` using

```c#
using kvandijk.Common.Logging;
using kvandijk.Common.Middleware;
...

// Load environment variables
DotenvLoader.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

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
