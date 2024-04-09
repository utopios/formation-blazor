namespace demomvvmblazor.Services;

public class GenerateurMotService
{
    private Random _random = new Random();
    private string[] mots = { "google", "facebook", "microsoft", "amazon" };
    public string GenererMot()
    {
        return mots[_random.Next(mots.Length)];
    }
}