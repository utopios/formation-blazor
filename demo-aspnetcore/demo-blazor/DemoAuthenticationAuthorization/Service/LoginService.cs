using DemoAuthenticationAuthorization.Models;

namespace DemoAuthenticationAuthorization.Service;

public class LoginService
{
    public User SendAuthentication(string username, string password)
    {
        if(username == "toto" && password == "toto")
            //Invoke des api rest 
            return new User() { Username = "toto", Password = "toto", Age = 20 };
        return null;
    }
    
    //Sauvegarder les informations dans localStorage
    
    //Récupérer les claims à partir d'un Token ou un utilisateur à partir d'un stockage

    public User FetchUserFromBrowser()
    {
        return null;
    }
}