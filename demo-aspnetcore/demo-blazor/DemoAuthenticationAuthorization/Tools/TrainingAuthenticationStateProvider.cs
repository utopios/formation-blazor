using System.Security.Claims;
using DemoAuthenticationAuthorization.Models;
using DemoAuthenticationAuthorization.Service;
using Microsoft.AspNetCore.Components.Authorization;

namespace DemoAuthenticationAuthorization.Tools;



public class TrainingAuthenticationStateProvider: AuthenticationStateProvider, IDisposable
{
    private LoginService _loginService;
    public User CurrentUser { get; set; } = new();
    public TrainingAuthenticationStateProvider(LoginService loginService)
    {
        _loginService = loginService;

        AuthenticationStateChanged += OnAuthenticationStateChangedAsyc;
    }

    private async void OnAuthenticationStateChangedAsyc(Task<AuthenticationState> task)
    {
        //Action Réponse à la notification
    }
    
    
    //Pour reconnecter un utilisateur
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();
        //var user = _loginService.FetchUserFromBrowser();
        var user = CurrentUser;
        if (user is not null)
        {
            var authenticationUser = _loginService.SendAuthentication(user.Username, user.Password);
            CurrentUser = authenticationUser;
            if (authenticationUser is not null)
            {
                principal = authenticationUser.ClaimsPrincipal();
            }
            else
            {
                return new(new());
            }
        }

        return new(principal);
    }

    public void Login(string username, string password)
    {
        var principal = new ClaimsPrincipal();
        var authenticationUser = _loginService.SendAuthentication(username,password);
        CurrentUser = authenticationUser;
        //On le stocke dans le nanvigateur

        if (authenticationUser is not null)
        {
            principal = authenticationUser.ClaimsPrincipal();
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    } 

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}