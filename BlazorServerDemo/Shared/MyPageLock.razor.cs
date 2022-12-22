using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorServerDemo.Shared;

public partial class MyPageLock
{
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

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

    [Parameter] public bool UnsavedChanges { get; set; } = true;

    private void ConfirmNavigation()
    {
        UnsavedChanges = false;
        NavigationActive = false;
        
        NavigationManager.NavigateTo(TargetLocation);
        //HACK - reenable unsaved changes
        UnsavedChanges = true;
    }
}