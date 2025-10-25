using OpenQA.Selenium;

namespace Task3;

public class MainPage : BasePage
{
    private ButtonElement alertsFrameWindowsButton = new(By.XPath("//*[contains(text(), 'Alerts')]"), "Alerts, Frame and Windows");

    private ButtonElement elementsButton = new(By.XPath("//*[text() = 'Elements']"), "Elements");

    public MainPage() : base(By.XPath("//*[contains(@class, 'banner-image')]"), "Main page")
    {
    }

    public void ClickAlertsFrameWindows() => alertsFrameWindowsButton.Click();

    public void ClickElementsButton() => elementsButton.Click();
}
