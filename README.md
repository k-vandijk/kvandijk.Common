
## How to contribute

To publish a new release, build using `dotnet build -c Release`, and then publish using `dotnet nuget push bin/Release/kvandijk.Common.1.0.0.nupkg --source "github" --api-key YOUR_GITHUB_PAT`

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
      <add key="ClearTextPassword" value="<GITHUB_PAT_TOKEN>" />
    </github>
  </packageSourceCredentials>
</configuration>
```

Then, you can install the package using `dotnet add package kvandijk.Common`