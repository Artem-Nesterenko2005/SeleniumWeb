using OpenQA.Selenium;

namespace Task3;

public class NestedFramesPage : BasePage
{
    private TextElement childText = new(By.XPath("html/body/p"), "Child text");

    private TextElement parentText = new(By.XPath("html/body"), "Parent text");

    private By locatorToParentFrame = By.XPath("//*[@id='frame1']");

    private By locatorToChildFrame = By.XPath("//*[contains(@srcdoc, 'Child')]");

    public NestedFramesPage() : base(By.XPath("//*[@id='framesWrapper']"), "Nested frames page")
    {
    }

    public string GetParentFrameText()
    {
        FramesUtils.FrameSwitch(locatorToParentFrame);
        var text = parentText.GetText();
        FramesUtils.MainContentSwitch();
        return text;
    }

    public string GetChildFrameText()
    {
        FramesUtils.FrameSwitch(locatorToParentFrame);
        FramesUtils.FrameSwitch(locatorToChildFrame);
        var text = childText.GetText();
        FramesUtils.MainContentSwitch();
        return text;
    }
}
