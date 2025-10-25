using OpenQA.Selenium;

namespace Task2;

public class BaseTest
{
    protected IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = SingleDriver.GetDriver;
    }

    [TearDown]
    public void TearDown()
    {
        SingleDriver.CloseDriver();
    }
}
