namespace Task2;

public class TestCase1 : BaseTest
{
    private MainPage mainPage;
    private AboutPage aboutPage;

    [SetUp]
    public void SetupTestCase()
    {
        mainPage = new MainPage();
        aboutPage = new AboutPage();
    }

    [Test]
    public void Test()
    {
        driver.Navigate().GoToUrl(DataUtility.GetConfigData.URL);
        Assert.That(mainPage.IsExistUnique, Is.True);
        
        mainPage.ClickAboutButton();
        Assert.That(aboutPage.IsExistUnique, Is.True);

        Assert.That(aboutPage.GetOnlineNumber(), Is.GreaterThanOrEqualTo(aboutPage.GetInGameNumber()));

        aboutPage.ClickShopButton();
        Assert.That(mainPage.IsExistUnique, Is.True);
    }
}
