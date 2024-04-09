using System.ComponentModel;
using System.Runtime.CompilerServices;
using demomvvmblazor.Models;
using demomvvmblazor.Services;

namespace demomvvmblazor.ViewModels;

public class LePenduViewModel : INotifyPropertyChanged
{
    public string Masque
    {
        get => _pendu.Masque;
    }
    public char Lettre { get; set; }
    public string Message { get; set; }
    public int NombreEssai
    {
        get => _pendu.NbEssaisRestants;
    }

    private Pendu _pendu;

    private GenerateurMotService _generateurMotService;

    public LePenduViewModel(GenerateurMotService generateurMotService)
    {
        _pendu = new Pendu(generateurMotService);
    }
    public void TesterLettre()
    {
        Message = _pendu.TestChar(Lettre);
        if (_pendu.TestWin())
        {
            Message = "Bravo ";
        }

        Lettre  = '\0';

        OnPropertyChanged("Message");
        OnPropertyChanged("Masque");
        OnPropertyChanged("NombreEssai");
        OnPropertyChanged("Lettre");
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}