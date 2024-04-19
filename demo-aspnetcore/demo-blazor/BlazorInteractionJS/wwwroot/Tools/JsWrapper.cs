using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.JSInterop;

namespace BlazorInteractionJS.wwwroot.Tools;

public static partial class JsWrapper
{
    [JSImport("showAlert", "script")]
    public static partial void ShowAlert([JSMarshalAs<JSType.String>] string message);

    
    [JSInvokable]
    public static void InvokeCSharpFromJs()
    {
        Debug.WriteLine("C# FROM js");
    }
}