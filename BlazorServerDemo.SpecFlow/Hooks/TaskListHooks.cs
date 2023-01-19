namespace BlazorServerDemo.SpecFlow.Hooks;

[Binding]
public class TaskListHooks
{
    private TaskListPageObject _taskList;
    
    [BeforeScenario("TaskList")]
    public async Task BeforeTaskListScenario(IObjectContainer container)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(
        //        new() { Headless = false, SlowMo = 1000 }
        );
        _taskList = new TaskListPageObject(browser);

        container.RegisterInstanceAs(playwright);
        container.RegisterInstanceAs(browser);
        container.RegisterInstanceAs(_taskList);
    }

    [AfterScenario("TaskList")]
    public async Task AfterScenario(IObjectContainer container)
    {
        await container.Resolve<IBrowser>().CloseAsync();
        container.Resolve<IPlaywright>().Dispose();
    }

    [AfterScenario()]
    public async Task AfterAnyScenario(IObjectContainer container)
    {
    }
}