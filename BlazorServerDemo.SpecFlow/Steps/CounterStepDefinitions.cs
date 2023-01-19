using BlazorServerDemo.SpecFlow.PageObjects;
using Xunit;

namespace BlazorServerDemo.SpecFlow.Steps;

[Binding]
public class CounterStepDefinitions
{
    private readonly CounterPageObject _counterPageObject;

    public CounterStepDefinitions(CounterPageObject counterPageObject)
    {
        _counterPageObject = counterPageObject;
    }

    [Given(@"a user in the counter page")]
    public async Task GivenAUserInTheCounterPage()
    {
        await _counterPageObject.NavigateAsync();
    }

    [When(@"the increase button is clicked (.*) times")]
    public async Task WhenTheIncreaseButtonIsClickedTimes(int times)
    {
        while (times-- > 0)
            await _counterPageObject.ClickIncreaseButton();
    }

    [Then(@"the counter value is (.*)")]
    public async Task ThenTheCounterValueIs(int value)
    {
        int counterValue = await _counterPageObject.CounterValue();
        
        Assert.Equal(value, counterValue);
    }

    [Then(@"the page has errors is (.*)")]
    public async Task ThenThePageHasErrorsIs(string errors)
    {
        bool expected = bool.Parse(errors);
        Assert.Equal(expected, await _counterPageObject.HasErrors());
        
    }
}