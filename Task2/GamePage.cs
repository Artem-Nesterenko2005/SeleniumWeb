using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Task2;

public class GamePage
{
    private const string uniqueElement = "//*[contains(text(),'Add to Cart')]";
    private const string pageTopGameDiscountPrice = "//*[contains(@class,'game_purchase_action')]//*[contains(@class,'discount_final_price')]";
    private const string pageTopGamePrice = "//*[contains(@class, 'game_purchase_price') and @data-price-final]";
    private const string pageTopGameName = "//*[@id = 'appHubAppName']";
    private const string pageTopGameDate = "//*[contains(@class,'release_date')]//*[contains(@class, 'date')]";

    public bool IsExistUnique()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(uniqueElement)).Displayed);
        return SingleDriver.GetDriver.FindElements(By.XPath(uniqueElement)).Count() > 0;
    }

    public ValueTuple<string, int, string> FirstPageTopGameInfo()
    {
        var info = new ValueTuple<string, int, string>();
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));

        wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(pageTopGameDate)).Enabled);
        info.Item1 = SingleDriver.GetDriver.FindElement(By.XPath(pageTopGameDate)).Text;

        if (SingleDriver.GetDriver.FindElements(By.XPath(pageTopGamePrice)).Count == 1)
        {
            wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(pageTopGamePrice)).Enabled);
            info.Item2 = int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(pageTopGamePrice)).Text.Split(" ")[0]);
        }
        else
        {
            wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(pageTopGameDiscountPrice)).Enabled);
            info.Item2 = int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(pageTopGameDiscountPrice)).Text.Split(" ")[0]);
        }
        wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(pageTopGameName)).Enabled);
        info.Item3 = SingleDriver.GetDriver.FindElement(By.XPath(pageTopGameName)).Text;
        return info;
    }
}
