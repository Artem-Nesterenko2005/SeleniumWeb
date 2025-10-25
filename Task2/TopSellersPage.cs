using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Task2;

public class TopSellersPage
{
    private const string moreTopSellersButton = "//button[@role = 'button']";

    public void ScrollDown()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(moreTopSellersButton)).Enabled);
        IWebElement findObject = SingleDriver.GetDriver.FindElement(By.XPath(moreTopSellersButton));
        var action = new Actions(SingleDriver.GetDriver);
        action.ScrollToElement(findObject).Perform();
    }

    public void ClickMoreTopSellersButton()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(moreTopSellersButton)));
        SingleDriver.GetDriver.FindElement(By.XPath(moreTopSellersButton)).Click();
    }
    public bool IsExistUnique()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(moreTopSellersButton)).Displayed);
        return SingleDriver.GetDriver.FindElements(By.XPath(moreTopSellersButton)).Count() == 1;
    }
}
