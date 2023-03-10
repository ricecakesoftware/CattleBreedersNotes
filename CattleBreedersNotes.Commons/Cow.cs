namespace RiceCakeSoftware.CattleBreedersNotes.Commons;

public class Cow
{
    public string Base64Image { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public int EstrousCycle { get; set; }
    public int GestationPeriod { get; set; }
}
