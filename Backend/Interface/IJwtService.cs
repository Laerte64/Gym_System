using Model;

namespace Interface;

public interface IJwtService
{
    string GenerateToken(User user);
}