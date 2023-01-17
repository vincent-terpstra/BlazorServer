namespace BlazorServerDemobUnit;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class CounterCSharpTests : TestContext
{
    [Fact]
    public void CounterStartsAtZero()
    {
        // Arrange
        var cut = RenderComponent<Counter>();

        // Assert that content of the paragraph shows counter at zero
        cut.Find("#counter-val").MarkupMatches("<div id='counter-val'>0</div>");
    }

    [Fact]
    public void ClickingButtonIncrementsCounter()
    {
        // Arrange
        var cut = RenderComponent<Counter>();

        // Act - click button to increment counter
        cut.Find("button").Click();

        // Assert that the counter was incremented
        cut.Find("#counter-val").MarkupMatches("<div id='counter-val'>1</div>");
    }
}