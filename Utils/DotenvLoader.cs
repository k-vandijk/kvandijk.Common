namespace kvandijk.Common.Utils;

/// <summary>
/// Provides functionality to load environment variables from a .env file located upwards in the directory structure.
/// Supports quoted values, comments, and values containing '='.
/// </summary>
public static class DotenvLoader
{
    public static void Load(string? fileName = null, int maxLevels = 3)
    {
        fileName ??= ".env";
        var filePath = FindFileUpwards(fileName, maxLevels);

        if (filePath == null)
        {
            throw new FileNotFoundException(".env file not found in any parent directory.");
        }

        SetEnvironmentVariables(filePath);
    }

    private static string? FindFileUpwards(string fileName, int maxLevels)
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
        int level = 0;

        while (dir != null && level < maxLevels)
        {
            var fullPath = Path.Combine(dir.FullName, fileName);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }

            dir = dir.Parent;
            level++;
        }

        return null;
    }

    private static void SetEnvironmentVariables(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        foreach (var rawLine in lines)
        {
            var line = rawLine.Trim();

            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            // Split only on the FIRST '=' → allows values to contain '='
            var idx = line.IndexOf('=');
            if (idx <= 0)
            {
                continue; // malformed line
            }

            var key = line[..idx].Trim();
            var value = line[(idx + 1) ..].Trim();

            // Remove surrounding quotes if present
            if ((value.StartsWith('"') && value.EndsWith('"')) ||
                (value.StartsWith('\'') && value.EndsWith('\'')))
            {
                value = value[1..^1];
            }

            Environment.SetEnvironmentVariable(key, value);
        }
    }
}