using CommunityToolkit.Mvvm.ComponentModel;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Models;

public partial class Cow : ObservableObject
{
    private readonly Commons.Cow _obj = new();

    [ObservableProperty]
    public byte[] _image = null;

    public string Base64Image
    {
        get => _obj.Base64Image;
        set => SetProperty(_obj.Base64Image, value, _obj, (o, v) => o.Base64Image = v);
    }

    public string Id
    {
        get => _obj.Id;
        set => SetProperty(_obj.Id, value, _obj, (o, v) => o.Id = v);
    }

    public string Name
    {
        get => _obj.Name;
        set => SetProperty(_obj.Name, value, _obj, (o, v) => o.Name = v);
    }

    public DateTime BirthDate
    {
        get => _obj.BirthDate;
        set => SetProperty(_obj.BirthDate, value, _obj, (o, v) => o.BirthDate = v);
    }

    public int EstrousCycle
    {
        get => _obj.EstrousCycle;
        set => SetProperty(_obj.EstrousCycle, value, _obj, (o, v) => o.EstrousCycle = v);
    }

    public int GestationPeriod
    {
        get => _obj.GestationPeriod;
        set => SetProperty(_obj.GestationPeriod, value, _obj, (o, v) => o.GestationPeriod = v);
    }
}
