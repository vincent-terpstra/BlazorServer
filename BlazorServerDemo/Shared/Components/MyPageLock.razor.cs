using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorServerDemo.Shared.Components;

public partial class MyPageLock
{
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
    
    public void SetUnSavedChanges(bool b)
    {
        UnsavedChanges = b;
    }
    
    public MyPageLock()
    {
        _myLocationChangingHandler = context =>
        {
            if (UnsavedChanges)
            {
                TargetLocation = context.TargetLocation;
                context.PreventNavigation();
                NavigationActive = true;
                StateHasChanged();
            }
            return ValueTask.CompletedTask;
        };
    }

    protected string TargetLocation { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {
            NavigationManager.RegisterLocationChangingHandler(_myLocationChangingHandler);
        }
    }

    private readonly Func<LocationChangingContext, ValueTask> _myLocationChangingHandler;
    
    public bool NavigationActive { get; set; }

    [Parameter] public bool UnsavedChanges { get; set; }

    private void ConfirmNavigation()
    {
        UnsavedChanges = false;
        NavigationActive = false;
        NavigationManager.NavigateTo(TargetLocation);
    }

    
}