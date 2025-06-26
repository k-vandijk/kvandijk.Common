using kvandijk.Common.Interfaces;

namespace kvandijk.Common.Services;

public class HashingService : IHashingService
{
    public string GenerateSalt()
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(16);
        return salt;
    }

    public string Hash(string value, string salt, string pepper)
    {
        var treatedValue = value + salt + pepper;
        var hashedValue = BCrypt.Net.BCrypt.HashPassword(treatedValue);
        return hashedValue;
    }

    public bool Verify(string enteredValue, string storedHash, string storedSalt, string pepper)
    {
        var treatedValue = enteredValue + storedSalt + pepper;
        return BCrypt.Net.BCrypt.Verify(treatedValue, storedHash);
    }
}