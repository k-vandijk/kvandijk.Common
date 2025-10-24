namespace kvandijk.Common.Services;

using kvandijk.Common.Interfaces;

/// <summary>
/// Service for hashing and verifying passwords using BCrypt.
/// </summary>
public class HashingService : IHashingService
{
    /// <summary>
    /// Generates a random salt for hashing.
    /// </summary>
    /// <returns>A random salt for hashing.</returns>
    public string GenerateSalt()
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(16);
        return salt;
    }

    /// <summary>
    /// Hashes a value using BCrypt with the provided salt and pepper.
    /// </summary>
    /// <param name="value">The value that you want to hash.</param>
    /// <param name="salt">The unique salt that's used when hashing the value.</param>
    /// <param name="pepper">The project-wide pepper that's used when hashing the value.</param>
    /// <returns>The hashed value.</returns>
    public string Hash(string value, string salt, string pepper)
    {
        var treatedValue = value + salt + pepper;
        var hashedValue = BCrypt.Net.BCrypt.HashPassword(treatedValue);
        return hashedValue;
    }

    /// <summary>
    /// Verifies an entered value against a stored hash, salt, and pepper.
    /// </summary>
    /// <param name="enteredValue">The value that you are trying to validate.</param>
    /// <param name="storedHash">The hash that you are trying to validate onto.</param>
    /// <param name="storedSalt">The unique salt that's used when hashing the value.</param>
    /// <param name="pepper">The project-wide pepper that's used when hashing the value.</param>
    /// <returns>Either `true` or `false`, whether the value matches with the stored hash.</returns>
    public bool Verify(string enteredValue, string storedHash, string storedSalt, string pepper)
    {
        var treatedValue = enteredValue + storedSalt + pepper;
        return BCrypt.Net.BCrypt.Verify(treatedValue, storedHash);
    }
}
