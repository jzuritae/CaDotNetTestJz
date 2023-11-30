namespace CaTestJz.Presentation.WebUI.Model.Authentication
{
    public record AuthenticationResponse(
        int Id,
        string FirstName,
        string LastName,
        string? Email,
        string AccessToken,
        string RefreshToken
    );
}
