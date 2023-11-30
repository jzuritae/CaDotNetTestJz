using CaTestJz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaTestJz.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(User user);
        Task<AuthenticationResult> Login(string  email, string password);
    }
}
