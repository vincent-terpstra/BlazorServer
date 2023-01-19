namespace BlazorServerDemo.SpecFlow.Tests.Counter;

public class CounterPageObject : BasePageObject
{
    public CounterPageObject(IBrowser browser) : base(browser, "counter")
    {
    }

    public async Task ClickIncreaseButton() => await Page.ClickAsync("#increase-btn");

    public async Task<int> CounterValue() => int.Parse(await Page.InnerTextAsync("#counter-val"));

    
}