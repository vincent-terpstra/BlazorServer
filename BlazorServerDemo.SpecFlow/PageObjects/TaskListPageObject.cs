namespace BlazorServerDemo.SpecFlow.PageObjects;

public class TaskListPageObject : BasePageObject
{
    public TaskListPageObject(IBrowser browser) : base(browser, "https://localhost:7171/Tasks/")
    {
    }

    public Task<string> GetHeader() => Page.GetByRole(AriaRole.Heading).InnerTextAsync();
}