using Autofac.Core;
using BlazorServerDemo.SpecFlow.PageObjects;
using BoDi;
using Microsoft.Playwright;
using Xunit;

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

    [Then(@"the page has errors")]
    public async Task ThenThePageHasErrors()
    {
        Assert.True(await _counterPageObject.HasErrors());
    }
    
    [Then(@"the page has no errors")]
    public async Task ThenThePageHasNoErrors()
    {
        Assert.False(await _counterPageObject.HasErrors());
    }
}