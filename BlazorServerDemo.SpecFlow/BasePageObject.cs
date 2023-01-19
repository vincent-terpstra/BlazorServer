using Microsoft.Playwright;

namespace BlazorServerDemo.SpecFlow.PageObjects;

public class BasePageObject
{

    private readonly string BaseUrl = "https://localhost:7171/";
    protected BasePageObject(IBrowser browser, string path = "")
    {
        Browser = browser;
        PagePath = BaseUrl + path;
    }

    private string PagePath { get; }
    private IBrowser Browser { get; }
    protected IPage Page { get; set; } = null!;

    public async Task NavigateAsync(string page = "")
    {
        Page = await Browser.NewPageAsync();
        await Page.GotoAsync(PagePath + page);
    }
    
    public async Task<bool> HasErrors()
        => await Page.Locator("#blazor-error-ui:visible").CountAsync() != 0;
    
}