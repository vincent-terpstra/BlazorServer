namespace BlazorServerDemo.SpecFlow.PageObjects;

public class TaskListPageObject : BasePageObject
{
    public TaskListPageObject(IBrowser browser) : base(browser, "Tasks/")
    {
    }

    public Task<string> GetHeader() => Page.GetByRole(AriaRole.Heading).InnerTextAsync();
}