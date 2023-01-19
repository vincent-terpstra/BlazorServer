namespace BlazorServerDemo.SpecFlow.Hooks;

[Binding]
public sealed class BrowserHooks
{
    [BeforeScenario("UseBrowser")]
    public async Task BeforeScenarioBrowser(IObjectContainer container)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync();
        
        container.RegisterInstanceAs(playwright);
        container.RegisterInstanceAs(browser);
    }
    
    [BeforeScenario("UseSlowBrowser")]
    public async Task BeforeScenarioSlowBrowser(IObjectContainer container)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(
            new() { Headless = false, SlowMo = 1000 }
        );
        
        container.RegisterInstanceAs(playwright);
        container.RegisterInstanceAs(browser);
    }

    [AfterScenario("UseBrowser")]
    [AfterScenario("UseSlowBrowser")]
    public async Task AfterScenarioBrowser(IObjectContainer container)
    {
        await container.Resolve<IBrowser>().CloseAsync();
        container.Resolve<IPlaywright>().Dispose();
    }
}