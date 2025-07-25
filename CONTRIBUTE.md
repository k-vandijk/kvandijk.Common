## How to contribute

To publish a new release, build using 

```terminal
dotnet build -c Release
```

Then publish using:

**Beware:** Set the version number to the correct version in the `.csproj` file and in the following command before running!

`Only once:`

Make sure there is a 'minimal working' xml file in the root of the repository named `nuget.config`:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
  </packageSources>
</configuration>
```

```terminal
dotnet nuget add source "https://nuget.pkg.github.com/<owner>/index.json" --name "github" --username <your-github-username> --password <your-personal-access-token> --store-password-in-clear-text
```

`Then:`

```terminal
dotnet nuget push src/bin/Release/kvandijk.Common.<VERSION>.nupkg --source github
```
