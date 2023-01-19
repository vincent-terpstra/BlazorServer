namespace BlazorServerDemo.SpecFlow.Tests.TaskList;

[Binding]
public class TaskListHooks
{
    private TaskListPageObject _taskList;
    
    [BeforeScenario("TaskList")]
    public void BeforeTaskListScenario(IObjectContainer container)
    {
        IBrowser browser = container.Resolve<IBrowser>();
        _taskList = new TaskListPageObject(browser);
        container.RegisterInstanceAs(_taskList);
    }
}