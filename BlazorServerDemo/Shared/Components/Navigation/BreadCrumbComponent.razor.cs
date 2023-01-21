using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorServerDemo.Shared.Components.Navigation;

public partial class BreadCrumbComponent
{
    [Inject] private NavigationManager Manager { get; set; }

    protected override void OnInitialized()
    {
        Manager.LocationChanged += UpdatePath;
        SetPath();
    }

    private void UpdatePath(object? sender, LocationChangedEventArgs e)
    {
        SetPath();
        StateHasChanged();
    }

    private void SetPath()
    {
        if (!CurrentPath.StartsWith(Manager.Uri))
        {
            CurrentPath = Manager.Uri;
            var subString = CurrentPath.Substring(Manager.BaseUri.Length);
            Routes.Clear();

            string[] routes = subString.Split('/');

            string path = string.Empty;

            foreach (var s in routes)
            {
                path += s;
                Routes.Add((s, path));
                path += '/';
            }


        }
    }

    string CurrentPath = string.Empty;
    List<(string Route, string Path)> Routes = new();
}