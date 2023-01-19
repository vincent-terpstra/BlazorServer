using Autofac.Core;

namespace BlazorServerDemo.SpecFlow.Steps;

[Binding]
public class TaskListStepDefinitions
{
    private readonly TaskListPageObject _taskListPageObject;
    private string _username = String.Empty;

    public TaskListStepDefinitions(TaskListPageObject taskListPageObject)
    {
        _taskListPageObject = taskListPageObject;
    }
    
    [Given(@"a user logged in as (.*)")]
    public void GivenAUserLoggedInAsUsername(string username)
    {
        _username = username;
    }
    
    [Given(@"the user is in the TaskList page")]
    public async Task GivenTheUserIsInTheTaskListPage()
    {
        await _taskListPageObject.NavigateAsync(_username);
    }

    [Then(@"the name on the page is (.*)")]
    public async Task ThenTheNameOnThePageIs(string username)
    {
        string header = await _taskListPageObject.GetHeader();
        Assert.StartsWith(username, header);
    }

    [When(@"the user adds a task ""(.*)""")]
    public async Task WhenTheUserAddsATask(string p0)
    {
        await _taskListPageObject.SetInputString(p0);
        await _taskListPageObject.SubmitTask();
    }
}