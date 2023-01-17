using Microsoft.Playwright;

namespace BlazorServerDemo.SpecFlow.PageObjects;

public class BasePageObject
{
    protected BasePageObject(IBrowser browser, string pagePath = "https://localhost:7171/")
    {
        Browser = browser;
        PagePath = pagePath;
    }

    public string PagePath { get; }
    public IBrowser Browser { get; }
    public IPage Page { get; set; } = null!;

    public async Task NavigateAsync()
    {
        Page = await Browser.NewPageAsync();
        await Page.GotoAsync(PagePath);
    }
}