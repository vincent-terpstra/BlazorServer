using System.Reflection;

namespace BlazorServerDemo.Pages.DataTableMovies;

internal static class DataTableHelpers
{
    public static IEnumerable<PropertyInfo> GetItemsPropertyInfo<TItem>() 
        => typeof(TItem)
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(x => x.CanRead);
}