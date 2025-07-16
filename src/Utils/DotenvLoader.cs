namespace kvandijk.Common.Utils;

/// <summary>
/// Utility class for loading environment variables from a .env file.
/// </summary>
public static class DotenvLoader
{
    /// <summary>
    /// Loads environment variables from a specified .env file.
    /// </summary>
    /// <param name="fileName">The name of the .env file, typically '.env'.</param>
    public static void Load(string? fileName = null)
    {
        var filePath = FindFileUpwards(fileName ?? ".env");

        if (filePath != null)
        {
            SetEnvironmentVariables(filePath);
            return;
        }

        throw new FileNotFoundException(".env file not found in any parent directory.");
    }

    private static void SetEnvironmentVariables(string filePath)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split("=", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                continue;
            }

            Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
        }
    }

    private static string? FindFileUpwards(string fileName)
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (dir != null)
        {
            var fullPath = Path.Combine(dir.FullName, fileName);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }

            dir = dir.Parent;
        }

        return null;
    }
}