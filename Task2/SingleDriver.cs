using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Task2;

public static class SingleDriver
{
    private static IWebDriver driver;
    private static bool isCreate = false;

    public static IWebDriver GetDriver
    {
        get
        {
            if (!isCreate)
            {
                var options = new ChromeOptions();
                options.AddArgument(DataUtility.GetConfigData.Language);
                options.AddArgument(DataUtility.GetConfigData.OpenMode);
                driver = new ChromeDriver(options);
                isCreate = true;
            }
            return driver;
        }
    }

    public static void CloseDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
            isCreate = false;
        }
    }
}
