using System.Security.Claims;

namespace DemoAuthenticationAuthorization.Models;

public class User
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public int Age { get; set; }
    
    public List<string> Roles { get; set; }

    public ClaimsPrincipal ClaimsPrincipal() => new(new ClaimsIdentity(new Claim[]
    {
        new(ClaimTypes.Name, Username),
        new("Age", Age.ToString())
    }));
}