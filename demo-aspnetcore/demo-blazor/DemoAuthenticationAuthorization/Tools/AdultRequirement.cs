using Microsoft.AspNetCore.Authorization;

namespace DemoAuthenticationAuthorization.Tools;

public class AdultRequirement : IAuthorizationRequirement
{
    public int MinAge { get; set; } = 18;
}