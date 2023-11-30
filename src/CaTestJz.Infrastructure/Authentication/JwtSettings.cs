namespace CaTestJz.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; } = null!; // we tell the compiler this will be null
        public int ExpiryMinutes { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }

    }
}
