using Autofac.Core;
using BlazorServerDemo.SpecFlow.PageObjects;
using BoDi;
using Microsoft.Playwright;

namespace BlazorServerDemo.SpecFlow.Hooks;

[Binding]
public class CounterHooks
{
    [BeforeScenario("Counter")]
    public async Task BeforeCounterScenario(IObjectContainer container)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync();
        var pageObject = new CounterPageObject(browser);
        
        container.RegisterInstanceAs(playwright);
        container.RegisterInstanceAs(browser);
        container.RegisterInstanceAs(pageObject);
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