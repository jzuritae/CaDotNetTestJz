using CaTestJz.Domain.Entities;

namespace CaTestJz.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
