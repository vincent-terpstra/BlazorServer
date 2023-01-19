namespace BlazorServerDemo.SpecFlow.Hooks;

[Binding]
public class CounterHooks
{
    private CounterPageObject _counterPageObject;
    
    [BeforeScenario("Counter")]
    public void BeforeCounterScenario(IObjectContainer container)
    {
        var browser = container.Resolve<IBrowser>();
        _counterPageObject = new CounterPageObject(browser);

        container.RegisterInstanceAs(_counterPageObject);
    }
}