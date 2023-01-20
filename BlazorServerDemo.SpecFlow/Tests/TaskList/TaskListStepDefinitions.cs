namespace BlazorServerDemo.SpecFlow.Tests.TaskList;

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

    [Then(@"the progress is (.*)")]
    public async Task ThenTheProgressIs(int p0)
    {
        int done = await _taskListPageObject.GetPercentDone();
        Assert.Equal(p0, done);
    }

    [Then(@"the task at (.*) is ""(.*)""")]
    public async Task ThenTheTaskAtIs(int idx, string taskText)
    {
        var taskList = await _taskListPageObject.GetTasks();
        if (taskList.Count > idx)
        {
            string inner = await taskList[idx].InnerTextAsync();
            Assert.Equal(taskText, inner);
        }
        else
        {
            Assert.False(true, "Not enough elements in the task list");
        }
    }

    [When(@"task (.*) is clicked")]
    public async Task WhenTaskIsSelected(int idx)
    {
        var taskList = await _taskListPageObject.GetTasks();
        if (taskList.Count > idx)
        {
            await taskList[idx].ClickAsync();
        }
        else
        {
            Assert.False(true, "Not enough elements in the task list");
        }
    }

    [Then(@"total tasks is (.*)")]
    public async Task ThenTotalTasksIs(int total)
    {
        var taskList = await _taskListPageObject.GetTasks();
        Assert.Equal(total, taskList.Count);
    }
}