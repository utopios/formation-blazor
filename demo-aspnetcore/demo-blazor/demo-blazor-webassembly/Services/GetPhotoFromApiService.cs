namespace demo_blazor_webassembly.Services;

public class GetPhotoFromApiService
{
    //private HttpClient _httpClient;
    private Random _random;

    public GetPhotoFromApiService(Random random)
    {
        //_httpClient = httpClient;
        _random = random;
    }

    public string GetRandomPicture()
    {
        return "https://picsum.photos/" + _random.Next(100, 1000);
    }
}