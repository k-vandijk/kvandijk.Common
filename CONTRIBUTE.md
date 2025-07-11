## How to contribute

To publish a new release, build using 

```terminal
dotnet build -c Release
```

Then publish using:

**Beware:** Set the version number to the correct version in the `.csproj` file and in the following command before running!

```terminal
dotnet nuget push bin/Release/kvandijk.Common.<VERSION>.nupkg --source "github" --api-key YOUR_GITHUB_PAT
```
