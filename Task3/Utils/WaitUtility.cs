using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Task3;

public static class WaitUtility
{
    private static WebDriverWait wait = new(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));

    public static void WaitClickable(IWebElement element) => wait.Until(ExpectedConditions.ElementToBeClickable(element));

    public static void WaitDisplayed(By element)
    {
        wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(ExpectedConditions.ElementIsVisible(element));
    }

    public static void WaitTextDisplayed(IWebElement element) => wait.Until(action => element.Displayed && element.Text != string.Empty);
}
