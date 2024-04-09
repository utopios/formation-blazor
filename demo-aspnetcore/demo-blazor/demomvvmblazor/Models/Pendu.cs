using demomvvmblazor.Services;

namespace demomvvmblazor.Models;

public class Pendu
{
    private string _motAtrouver;
    private string _masque;
    private int _nbEssaisTotal = 10;
    private int _nbEssaisRestants;
    private string _letresTestees = "";

    

    public int NbEssaisTotal
    {
        get => _nbEssaisTotal;
    }

    public int NbEssaisRestants
    {
        get => _nbEssaisRestants;
    }

    public Pendu(GenerateurMotService generateurMotService)
    {
        _nbEssaisRestants = _nbEssaisTotal;
        _motAtrouver = generateurMotService.GenererMot();
        // 1ere génération du masque
        GenererMasque();
        // Alternatives pour la première génération:
        //_masque = new string('*', _motAtrouver.Length);
        //_masque = string.Concat(Enumerable.Repeat("*", _motAtrouver.Length));
    }

    public Pendu(GenerateurMotService generateurMotService, int nbEssais) : this(generateurMotService)
    {
        _nbEssaisTotal = nbEssais;
        _nbEssaisRestants = nbEssais;
    }

    public string TestChar(char lettre)
    {
        if (_nbEssaisRestants > 0)
        {
            if (_letresTestees.Contains(lettre))
                return "Lettre déjà testée !!!";

            _letresTestees += lettre;
            if (_motAtrouver.Contains(lettre))
                return "La lettre est dans le mot !";

            _nbEssaisRestants--;
            return "La lettre n'est pas dans le mot...";
        }

        return "Vous avez perdu";

    }

    public bool TestWin()
    {
        //if (_masque.Contains('*'))
        //    return false;
        //return true;

        return !_masque.Contains('_');
    }

    public void GenererMasque()
    {
        _masque = "";
        foreach (char lettre in _motAtrouver)
        {
            if (_letresTestees.Contains(lettre))
                _masque += lettre;
            else
                _masque += '_';
        }
    }

    //Propriété Masque sans attribut masque => généré à chaque fois qu'on get
    public string Masque
    {
        get
        {
            string masque = "";
            foreach (char lettre in _motAtrouver)
            {
                if (_letresTestees.Contains(lettre))
                    masque += lettre;
                else
                    masque += '_';
            }

            _masque = masque;
            return masque;
        }
    }
}
