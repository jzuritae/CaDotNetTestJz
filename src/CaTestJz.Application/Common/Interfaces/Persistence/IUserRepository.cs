using CaTestJz.Application.Services.Authentication;
using CaTestJz.Domain.Entities;

namespace CaTestJz.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        public Task<AuthenticationResult> GetUser(string email, string pasword);
        public void Add(User user);
    }
}
