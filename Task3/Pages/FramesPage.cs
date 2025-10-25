using OpenQA.Selenium;

namespace Task3;

public class FramesPage : BasePage
{
    private TextElement frameText = new(By.XPath("html/body"), "Child frame");

    private By locatorToParentFrame = By.XPath("//*[@id='frame1']");

    private By locatorToChildFrame = By.XPath("//*[@id='frame2']");

    public FramesPage() : base(By.XPath("//*[contains(@class,'text-center') and text() = 'Frames']"), "Frames page")
    {
    }

    public string GetParentFrameText()
    {
        FramesUtils.FrameSwitch(locatorToParentFrame);
        var text = frameText.GetText();
        FramesUtils.MainContentSwitch();
        return text;
    }

    public string GetChildFrameText()
    {
        FramesUtils.FrameSwitch(locatorToChildFrame);
        var text = frameText.GetText();
        FramesUtils.MainContentSwitch();
        return text;
    }
}
