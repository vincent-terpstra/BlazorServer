using System.Reflection;

namespace BlazorServerDemo.Pages.MoviesTest;

internal static class DataTableHelpers
{
    public static IEnumerable<PropertyInfo> GetItemsPropertyInfo<TItem>() 
        => typeof(TItem)
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(x => x.CanRead);
}