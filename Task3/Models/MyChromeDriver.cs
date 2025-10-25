using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Task3;

public class MyChromeDriver : IMyWebDriver
{
    public IWebDriver CreateDriver()
    {
        var options = new ChromeOptions();
        if (Enum.TryParse<PageLoadStrategy>(DataUtility.GetConfigData.PageLoadStrategy, ignoreCase: true, out var strategy))
        {
            options.PageLoadStrategy = strategy;
        }
        options.AddArgument(DataUtility.GetConfigData.Language);
        options.AddArgument(DataUtility.GetConfigData.OpenMode);

        var driver = new ChromeDriver(options);
        if (DataUtility.GetConfigData.ScreenModeMaximize)
        {
            driver.Manage().Window.Maximize();
        }
        return driver;
    }
}
