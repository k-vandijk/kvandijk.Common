## How to contribute

To publish a new release, build using 

```terminal
dotnet build -c Release
```

Then publish using

```terminal
dotnet nuget push bin/Release/kvandijk.Common.1.0.0.nupkg --source "github" --api-key YOUR_GITHUB_PAT
```
