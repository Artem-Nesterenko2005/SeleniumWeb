namespace Task3;

public abstract class BaseTest
{
    [SetUp]
    public void Setup()
    {
        SingleDriver.GetDriver.Navigate().GoToUrl(DataUtility.GetConfigData.URL);
    }

    [TearDown]
    public void TearDown()
    {
        SingleDriver.CloseDriver();
    }
}
