using CaTestJz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaTestJz.Application.Services.Authentication
{
    public record AuthenticationResult
    {
        public User User { get; set; } = new();
        public string? AccessToken { get; set; } = null;
        public string? RefreshToken { get; set; } = null;
        public string? AuthMessage { get; set; } = null;
        public bool AllowLogin { get; set; } = false;
    }
}
