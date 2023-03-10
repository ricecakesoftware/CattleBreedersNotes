namespace RiceCakeSoftware.CattleBreedersNotes.Api.Models;

public class AppSettings
{
    public string AccessToken { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string SigningKey { get; set; } = string.Empty;
}
