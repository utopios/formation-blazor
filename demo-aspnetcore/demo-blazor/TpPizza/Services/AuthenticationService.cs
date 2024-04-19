using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TpPizza.Models;
using TpPizza.Tools;

namespace TpPizza.Services;

public class AuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationDataMemoryStorage _authenticationDataMemoryStorage;

    public AuthenticationService(HttpClient httpClient, AuthenticationDataMemoryStorage authenticationDataMemoryStorage)
    {
        _httpClient = httpClient;
        _authenticationDataMemoryStorage = authenticationDataMemoryStorage;
    }

    public async Task<User?> SendAuthenticateRequestAsync(string username, string password)
    {
        if (password == "formation")
        {
            var response = await _httpClient.GetAsync($"/sample-data/{username}.json");

            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                var claimPrincipal = CreateClaimsPrincipalFromToken(token);
                var user = User.FromClaimsPrincipal(claimPrincipal);
                PersistUserToBrowser(token);

                return user;
            }
        }

        return null;
    }

    public void PersistUserToBrowser(string token) => _authenticationDataMemoryStorage.Token = token;

    private ClaimsPrincipal CreateClaimsPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var identity = new ClaimsIdentity();

        if (tokenHandler.CanReadToken(token))
        {
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            identity = new ClaimsIdentity(jwtSecurityToken.Claims, "formation");
        }

        return new ClaimsPrincipal(identity);
    }

    public User? FetchUserFromBrowser()
    {
        var claimsPrincipal = CreateClaimsPrincipalFromToken(_authenticationDataMemoryStorage.Token);
        var user = User.FromClaimsPrincipal(claimsPrincipal);

        return user;
    }

    public void ClearBrowserUserData() => _authenticationDataMemoryStorage.Token = "";
}