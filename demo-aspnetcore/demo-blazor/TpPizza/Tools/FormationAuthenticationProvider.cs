using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using TpPizza.Models;
using TpPizza.Services;

namespace TpPizza.Tools;

public class FormationAuthenticationProvider : AuthenticationStateProvider, IDisposable
{
    private readonly AuthenticationService _authenticationService;

    public User? CurrentUser { get; set; } = new();

    public FormationAuthenticationProvider(AuthenticationService authenticationService)
    {
        AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
        _authenticationService = authenticationService;
    }

    private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
    {
        var authenticationState = await task;

        if (authenticationState is not null)
        {
            CurrentUser = User.FromClaimsPrincipal(authenticationState.User);
        }
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();
        var user = _authenticationService.FetchUserFromBrowser();

        if (user is not null)
        {
            var authenticatedUser = await _authenticationService.SendAuthenticateRequestAsync(user.Username, user.Password);
            CurrentUser = authenticatedUser;

            if (authenticatedUser is not null)
            {
                principal = authenticatedUser.ToClaimsPrincipal();
            }
        }

        return new(principal);
    }

    public async Task LoginAsync(string username, string password)
    {
        var principal = new ClaimsPrincipal();
        var user = await _authenticationService.SendAuthenticateRequestAsync(username, password);
        CurrentUser = user;

        if (user is not null)
        {
            principal = user.ToClaimsPrincipal();
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public void Logout()
    {
        _authenticationService.ClearBrowserUserData();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));
    }

    public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;
}
