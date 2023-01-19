namespace BlazorServerDemo.SpecFlow.Hooks;

[Binding]
public class CounterHooks
{
    private CounterPageObject _counterPageObject;
    
    [BeforeScenario("Counter")]
    public async Task BeforeCounterScenario(IObjectContainer container)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(
        //    new() { Headless = false, SlowMo = 2000 }
        );
        _counterPageObject = new CounterPageObject(browser);

        container.RegisterInstanceAs(playwright);
        container.RegisterInstanceAs(browser);
        container.RegisterInstanceAs(_counterPageObject);
    }

    [AfterScenario("Counter")]
    public async Task AfterScenario(IObjectContainer container)
    {
        var browser = container.Resolve<IBrowser>();
        await browser.CloseAsync();
        var playwright = container.Resolve<IPlaywright>();
        playwright.Dispose();
    }
}