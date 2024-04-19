using System.Runtime.InteropServices.JavaScript;

namespace BlazorInteractionJS.wwwroot.Tools;

public static partial class JsWrapper
{
    [JSImport("showAlert", "script")]
    public static partial void ShowAlert([JSMarshalAs<JSType.String>] string message);
}