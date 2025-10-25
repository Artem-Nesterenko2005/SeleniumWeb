using OpenQA.Selenium;

namespace Task3;

public class BrowserWindowsPage : BasePage
{
    private ButtonElement addTabButton = new(By.XPath("//button[@id = 'tabButton']"), "Add tab");

    public BrowserWindowsPage() : base(By.XPath("//button[@id = 'tabButton']"), "Browser and Windows page")
    {
    }

    public void ClickAddTabButton() => addTabButton.Click();
}
