using DemoAuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoAuthenticationAuthorization.Tools;

public class AdultRequirementHandler : AuthorizationHandler<AdultRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdultRequirement requirement)
    {
        var user = User.FromClaimsPrincipal(context.User);
        if (user.Age >= requirement.MinAge)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}