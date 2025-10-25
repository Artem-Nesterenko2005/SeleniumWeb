using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Task2;

class MainPage
{
    private const string uniqueElement = "//*[@id='home_video_desktop']";

    private const string aboutButton = "//*[contains(@id, 'global_header')]//a[contains(text(),'About')]";

    private const string newAndInterestingButton = "//*[contains(@id, 'noteworthy_tab')]//span[contains(@class, 'pulldown')]";

    private const string salesLeadersButton = "//a[contains(text(), 'Top Sellers')]";

    public void ClickAboutButton() => SingleDriver.GetDriver.FindElement(By.XPath(aboutButton)).Click();

    public bool IsExistUnique()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(uniqueElement)).Displayed);
        return SingleDriver.GetDriver.FindElements(By.XPath(uniqueElement)).Count() == 1;
    }

    public void MoveToNewAndInteresting()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(newAndInterestingButton)));
        var action = new Actions(SingleDriver.GetDriver);
        action.MoveToElement(SingleDriver.GetDriver.FindElement(By.XPath(newAndInterestingButton))).Perform();
    }

    public void ClickSalesLeadersButton()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(salesLeadersButton)).Displayed);
        SingleDriver.GetDriver.FindElement(By.XPath(salesLeadersButton)).Click();
    }
}
