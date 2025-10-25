using OpenQA.Selenium;

namespace Task2;

public class AboutPage
{
    private const string gamersOnline = "//*[contains(*//@class,'gamers_online')]";

    private const string gamersInGame = "//*[contains(*//@class,'gamers_in_game')]";

    private const string shopButton = "//*[@aria-label = 'Global Menu']//a[contains(@data-tooltip-content,'.submenu_Store')]";

    public int GetOnlineNumber() => ParseNumberGamers(SingleDriver.GetDriver.FindElement(By.XPath(gamersOnline)).Text);

    public int GetInGameNumber() => ParseNumberGamers(SingleDriver.GetDriver.FindElement(By.XPath(gamersInGame)).Text);

    private int ParseNumberGamers(string gamersString)
    {
        gamersString = gamersString.Split("\n")[1];
        gamersString = gamersString.Replace(",", "");
        return int.Parse(gamersString);
    }

    public void ClickShopButton() => SingleDriver.GetDriver.FindElement(By.XPath(shopButton)).Click();

    public bool IsExistUnique => SingleDriver.GetDriver.FindElements(By.XPath(gamersOnline)).Count() == 1;
}
