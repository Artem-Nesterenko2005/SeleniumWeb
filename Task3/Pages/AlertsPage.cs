using OpenQA.Selenium;

namespace Task3;

public class AlertsPage : BasePage
{
    private ButtonElement clickToAlertButton = new (By.XPath("//button[@id = 'alertButton']"), "Click to alert");

    private ButtonElement confirmBoxButton = new (By.XPath("//button[@id = 'confirmButton']"), "Confirm box");

    private ButtonElement promtBoxButton = new (By.XPath("//button[@id = 'promtButton']"), "Promt box");

    private TextElement confirmText = new (By.XPath("//*[@id = 'confirmResult']"), "Confirm text");

    private TextElement promptText = new (By.XPath("//*[@id = 'promptResult']"), "Prompt text");

    public AlertsPage() : base(By.XPath("//*[contains(@class, 'left-pannel')]"), "Alert, Frame and Windows page")
    {
    }

    public void ClickToAlertButton() => clickToAlertButton.Click();

    public void ClickConfirmBoxButton() => confirmBoxButton.Click();

    public void ClickPromptBoxButton() => promtBoxButton.Click();

    public string GetConfirmText() => confirmText.GetText();

    public string GetPromptText() => promptText.GetText();
}
