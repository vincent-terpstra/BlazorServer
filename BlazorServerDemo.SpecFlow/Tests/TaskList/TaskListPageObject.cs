namespace BlazorServerDemo.SpecFlow.Tests.TaskList;

public class TaskListPageObject : BasePageObject
{
    public TaskListPageObject(IBrowser browser) : base(browser, "Tasks/")
    {
    }

    public Task<string> GetHeader() => Page.GetByRole(AriaRole.Heading).InnerTextAsync();

    public Task SetInputString(string input) => Page.GetByRole(AriaRole.Textbox).FillAsync(input);

    public Task SubmitTask() => Page.GetByRole(AriaRole.Button).ClickAsync();
}