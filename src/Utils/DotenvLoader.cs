namespace kvandijk.Common.Utils;

/// <summary>
/// Utility class for loading environment variables from a .env file.
/// </summary>
public static class DotenvLoader
{
    /// <summary>
    /// Loads environment variables from a specified .env file.
    /// </summary>
    /// <param name="filePath">The path to the .env file.</param>
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

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
}