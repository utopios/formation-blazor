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
    
    public static User FromClaimsPrincipal(ClaimsPrincipal principal) => new()
    {
        Username = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
        Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
        Age = Convert.ToInt32(principal.FindFirst(nameof(Age))?.Value),
        Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList()
    };
}