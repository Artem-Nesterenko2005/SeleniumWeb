using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2;

public class MoreTopSellersPage
{
    private const string numberOfPlayersList = "//*[@data-collapse-name = 'category3']//*[contains(@class, 'block_header')]";

    private const string moreTagsInput = "//input[@id = 'TagSuggest']";

    private const string checkBox = "//span[@data-gpfocus = 'item' and @data-loc = '";

    private const string topGameDate = "//*[@id = 'search_resultsRows']//a[1]//*[contains(@class,'search_released')]";
    private const string topGamePrice = "//*[@id = 'search_resultsRows']//a[1]//*[contains(@class,'discount_final_price')]";
    private const string topGameName = "//*[@id = 'search_resultsRows']//a[1]//*[contains(@class,'title')]";

    private const string numberGamesByTag = "//*[@class='search_results_count']";

    private const string listGames = "//*[@id='search_resultsRows']//a";

    private const string topGameButton = "//*[@id = 'search_resultsRows']//a[1]";

    private const string narrowByNumber = "//*[@data-collapse-name = 'category3']//*[contains(@class,'block_content')]";

    private int firstNumberGamesByTag;

    public void ClickVisibleCheckBox(string checkBoxName)
    {
        var locator = checkBox + checkBoxName + "']";
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locator)));
        SingleDriver.GetDriver.FindElement(By.XPath(locator)).Click();
    }

    public void ClickNumberOfPlayersList()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(numberOfPlayersList)));
        SingleDriver.GetDriver.FindElement(By.XPath(numberOfPlayersList)).Click();
    }

    public void ClickLanCoopCheckBox(string checkBoxName)
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(narrowByNumber)).GetAttribute("style") == "display: block;");
        ClickVisibleCheckBox(checkBoxName);
        RememberNumberGamesByTag();
    }

    public void ClickTopGameButton()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(action => int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(numberGamesByTag)).Text.Split(" ")[0]) != firstNumberGamesByTag);
        SingleDriver.GetDriver.FindElement(By.XPath(topGameButton)).Click();
    }

    private void RememberNumberGamesByTag()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(numberGamesByTag)).Displayed);
        this.firstNumberGamesByTag = int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(numberGamesByTag)).Text.Split(" ")[0]);
    }

    public void InputMoreTag()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(moreTagsInput)).Enabled);
        SingleDriver.GetDriver.FindElement(By.XPath(moreTagsInput)).SendKeys("Action");
    }

    public ValueTuple<string, int, string> FirstTopGameInfo()
    {
        var info = new ValueTuple<string, int, string>();
        info.Item1 = SingleDriver.GetDriver.FindElement(By.XPath(topGameDate)).Text;
        info.Item2 = int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(topGamePrice)).Text.Split(" ")[0]);
        info.Item3 = SingleDriver.GetDriver.FindElement(By.XPath(topGameName)).Text;
        return info;
    }

    public bool ChooseCheckBox(string checkBoxName)
    {
        var locator = checkBox + checkBoxName + "']";
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(locator)).Enabled);
        var element = SingleDriver.GetDriver.FindElement(By.XPath(locator));
        string classAttribute = element.GetAttribute("class");
        return classAttribute != null && classAttribute.Contains("checked");
    }

    public bool isExistUnique()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(d => SingleDriver.GetDriver.FindElement(By.XPath(topGameButton)).Displayed);
        return SingleDriver.GetDriver.FindElements(By.XPath(topGameButton)).Count() == 1;
    }

    public int GamesNumber()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(action => int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(numberGamesByTag)).Text.Split(" ")[0]) != firstNumberGamesByTag);
        return int.Parse(SingleDriver.GetDriver.FindElement(By.XPath(numberGamesByTag)).Text.Split(" ")[0]);
    }

    public int GamesInListCount()
    {
        WebDriverWait wait = new WebDriverWait(SingleDriver.GetDriver, TimeSpan.FromSeconds(DataUtility.GetConfigData.WaitTime));
        wait.Until(action => SingleDriver.GetDriver.FindElement(By.XPath(listGames)).Displayed);
        return SingleDriver.GetDriver.FindElements(By.XPath(listGames)).Count;
    }
}
