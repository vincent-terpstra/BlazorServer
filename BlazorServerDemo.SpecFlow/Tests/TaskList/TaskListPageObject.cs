using System.Text.RegularExpressions;

namespace BlazorServerDemo.SpecFlow.Tests.TaskList;

public class TaskListPageObject : BasePageObject
{
    public TaskListPageObject(IBrowser browser) : base(browser, "Tasks/")
    {
    }

    public Task<string> GetHeader() => Page.GetByRole(AriaRole.Heading).InnerTextAsync();

    public Task SetInputString(string input) => Page.Locator("#input_task").FillAsync(input);

    public Task SubmitTask() => Page.Locator("#add_task").ClickAsync();

    public async Task<int> GetPercentDone()
    {
        var loc = Page.Locator("#progress_bar");
        var style = await loc.GetAttributeAsync("style") ?? string.Empty;
        var match = Regex.Match(style , @"\d+", RegexOptions.IgnoreCase);
        return match.Success ? int.Parse(match.Value) : 0;
    }

    public Task<IReadOnlyList<ILocator>> GetTasks() => Page.GetByRole(AriaRole.Listitem).AllAsync();
    
}