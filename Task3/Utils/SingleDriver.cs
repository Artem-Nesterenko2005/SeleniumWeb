using OpenQA.Selenium;

namespace Task3;

public class SingleDriver
{
    private static IWebDriver driver;

    private static IMyWebDriver driverFactory;

    public static IWebDriver GetDriver
    {
        get
        {
            if (driver == null)
            {
                var browserType = DataUtility.GetConfigData.BrowserType.ToLower();
                switch (browserType)
                {
                    case "chrome":
                        driverFactory = new MyChromeDriver();
                        break;
                    case "firefox":
                        driverFactory = new MyFirefoxDriver();
                        break;
                }
                driver = driverFactory.CreateDriver();
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
        }
    }
}
