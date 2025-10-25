using OpenQA.Selenium;

namespace Task3;

public class TextElement : BaseElement
{
    public TextElement(By byLocator, string name) : base(byLocator, name)
    {
    }

    public string GetText()
    {
        try
        {
            WaitUtility.WaitTextDisplayed(FindElement());
            return FindElement().Text;
        }
        catch (Exception)
        {
            var scroll = (IJavaScriptExecutor)SingleDriver.GetDriver;
            scroll.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", FindElement());
            return FindElement().Text;
        }
    }
}
