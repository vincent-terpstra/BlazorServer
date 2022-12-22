using BlazorServerDemo.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorServerDemo.Pages;

public partial class Index
{
    [CascadingParameter]
    private MyPageLock? UnsavedChanges { get; set; }

    private void EnterEditMode()
    {
        UnsavedChanges?.SetUnSavedChanges(true);
    }
}