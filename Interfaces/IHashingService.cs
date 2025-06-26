namespace kvandijk.Common.Interfaces;

public interface IHashingService
{
    string GenerateSalt();
    string Hash(string value, string salt, string pepper);
    bool Verify(string enteredValue, string storedHash, string storedSalt, string pepper);
}