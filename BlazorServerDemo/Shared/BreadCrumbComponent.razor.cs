using Microsoft.AspNetCore.Components.Routing;

namespace BlazorServerDemo.Shared;

public partial class BreadCrumbComponent
{
    protected override void OnInitialized()
    {
        _manager.LocationChanged += UpdatePath;
        SetPath();
    }

    private void UpdatePath(object? sender, LocationChangedEventArgs e)
    {
        SetPath();
        StateHasChanged();
    }

    private void SetPath()
    {
        if (!CurrentPath.StartsWith(_manager.Uri))
        {
            CurrentPath = _manager.Uri;
            var subString = CurrentPath.Substring(_manager.BaseUri.Length);
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