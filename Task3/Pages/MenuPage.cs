using OpenQA.Selenium;

namespace Task3;

public class MenuPage : BasePage
{
    private ButtonElement webElementsButton = new(By.XPath("//*[contains(@class,'menu-list')]//*[contains(text(), 'Tables')]"), "Web elements");

    private ButtonElement browserWindowsTab = new(By.XPath("//*[contains(@class, 'show')]//*[text() = 'Browser Windows']"), "Browser windows Tab");

    private ButtonElement alertsTab = new(By.XPath("//*[contains(@class, 'show')]//*[text() = 'Alerts']"), "Alerts Tab");

    private ButtonElement framesTab = new(By.XPath("//*[contains(@class, 'show')]//*[text() = 'Frames']"), "Frames Tab");

    private ButtonElement nestedFramesTab = new(By.XPath("//*[contains(@class, 'show')]//*[text() = 'Nested Frames']"), "Nested frames Tab");

    private ButtonElement linksButton = new(By.XPath("//*[contains(@class, 'show')]//*[text() = 'Links']"), "Links");

    private ButtonElement elementsButton = new(By.XPath("//*[contains(@class,'header-wrapper')]//*[contains(text(),'Elements')]"), "Elements");

    public MenuPage() : base(By.XPath("//*[contains(@class,'left-pannel')]"), "Menu page")
    {
    }

    public void ClickBrowserWindowsTab() => browserWindowsTab.Click();

    public void ClickAlertsTab() => alertsTab.Click();

    public void ClickFramesTab() => framesTab.Click();

    public void ClickNestedFramesTab() => nestedFramesTab.Click();

    public void ClickWebElementsButton() => webElementsButton.Click();

    public void ClickElementsButton() => elementsButton.Click();

    public void ClickLinksButton() => linksButton.Click();
}
