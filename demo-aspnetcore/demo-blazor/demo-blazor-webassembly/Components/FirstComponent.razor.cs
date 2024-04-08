using Microsoft.AspNetCore.Components;

namespace demo_blazor_webassembly.Components;

public partial class FirstComponent
{
    [Parameter]
    public string Lastname { get; set; }
}