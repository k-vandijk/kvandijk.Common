namespace kvandijk.Common.Interfaces;

/// <summary>
/// Service for hashing and verifying passwords using BCrypt.
/// </summary>
public interface IHashingService
{
    /// <summary>
    /// Generates a random salt for hashing.
    /// </summary>
    /// <returns>A random salt for hashing.</returns>
    string GenerateSalt();

    /// <summary>
    /// Hashes a value using BCrypt with the provided salt and pepper.
    /// </summary>
    /// <param name="value">The value that you want to hash.</param>
    /// <param name="salt">The unique salt that's used when hashing the value.</param>
    /// <param name="pepper">The project-wide pepper that's used when hashing the value.</param>
    /// <returns>The hashed value.</returns>
    string Hash(string value, string salt, string pepper);

    /// <summary>
    /// Verifies an entered value against a stored hash, salt, and pepper.
    /// </summary>
    /// <param name="enteredValue">The value that you are trying to validate.</param>
    /// <param name="storedHash">The hash that you are trying to validate onto.</param>
    /// <param name="storedSalt">The unique salt that's used when hashing the value.</param>
    /// <param name="pepper">The project-wide pepper that's used when hashing the value.</param>
    /// <returns>Either `true` or `false`, whether the value matches with the stored hash.</returns>
    bool Verify(string enteredValue, string storedHash, string storedSalt, string pepper);
}