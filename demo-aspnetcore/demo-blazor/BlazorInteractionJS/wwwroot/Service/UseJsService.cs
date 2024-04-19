using Microsoft.JSInterop;

namespace BlazorInteractionJS.wwwroot.Service;

public class UseJsService : IAsyncDisposable
{
    private IJSRuntime _jsRuntime;
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    public UseJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;

        
    }

    private async Task AwaitReference()
    {
        _accessorJsRef = new (await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/functionService.js"));
    }

    public async Task StartJs()
    {
        if (_accessorJsRef.IsValueCreated is false)
        {
            await AwaitReference();
        }

        await _accessorJsRef.Value.InvokeVoidAsync("simpleJsFunction");

    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }
}