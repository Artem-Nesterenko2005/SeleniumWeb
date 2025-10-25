using OpenQA.Selenium;

namespace Task3;

public abstract class BaseElement
{
    protected readonly string name;

    protected readonly By byLocator;

    public BaseElement(By byLocator, string name)
    {
        this.name = name;
        this.byLocator = byLocator;
    }

    protected IWebElement FindElement() => SingleDriver.GetDriver.FindElement(byLocator);

    public void Click()
    {
        try
        {
            WaitUtility.WaitClickable(FindElement());
            Logger.LogInfo($"Нажатие на кнопку {name}");
            FindElement().Click();
        }
        catch(ElementClickInterceptedException)
        {
            IJavaScriptExecutor scroll = (IJavaScriptExecutor)SingleDriver.GetDriver;
            scroll.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", FindElement());
            FindElement().Click();
        }
        catch (NoSuchElementException)
        {
            IJavaScriptExecutor scroll = (IJavaScriptExecutor)SingleDriver.GetDriver;
            scroll.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", FindElement());
            FindElement().Click();
        }
    }

    public bool IsDisplayed()
    {
        try
        {
            WaitUtility.WaitDisplayed(byLocator);
            var displayed = FindElement().Displayed;
            return true;
        }
        catch(Exception)
        {
            return false;
        }
    }
}
