namespace Task2;

public class TestCase2 : BaseTest
{
    private MainPage mainPage;
    private TopSellersPage topSellersPage;
    private MoreTopSellersPage moreTopSellersPage;
    private GamePage gamePage;
    private TestData testData;

    [SetUp]
    public void SetupTestCase()
    {
        mainPage = new MainPage();
        topSellersPage = new TopSellersPage();
        moreTopSellersPage = new MoreTopSellersPage();
        gamePage = new GamePage();
        testData = DataUtility.GetTestData;
    }

    [Test]
    public void Test()
    {
        driver.Navigate().GoToUrl(DataUtility.GetConfigData.URL);
        Assert.That(mainPage.IsExistUnique, Is.True);

        mainPage.MoveToNewAndInteresting();
        mainPage.ClickSalesLeadersButton();
        Assert.That(topSellersPage.IsExistUnique, Is.True);

        topSellersPage.ScrollDown();
        topSellersPage.ClickMoreTopSellersButton();
        Assert.That(moreTopSellersPage.isExistUnique(), Is.True);

        moreTopSellersPage.ClickVisibleCheckBox(testData.OS);
        Assert.That(moreTopSellersPage.ChooseCheckBox(testData.OS), Is.True);

        moreTopSellersPage.ClickNumberOfPlayersList();
        moreTopSellersPage.ClickLanCoopCheckBox(testData.NumbersPlayers);
        Assert.That(moreTopSellersPage.ChooseCheckBox(testData.NumbersPlayers), Is.True);

        moreTopSellersPage.InputMoreTag();
        moreTopSellersPage.ClickVisibleCheckBox(testData.Tag);
        Assert.That(moreTopSellersPage.GamesNumber(), Is.EqualTo(moreTopSellersPage.GamesInListCount()));
        Assert.That(moreTopSellersPage.ChooseCheckBox(testData.Tag), Is.True);

        var infoTopGame = moreTopSellersPage.FirstTopGameInfo();
        moreTopSellersPage.ClickTopGameButton();
        var infoPageTopGame = gamePage.FirstPageTopGameInfo();
        Assert.That(gamePage.IsExistUnique, Is.True);
        Assert.That(infoTopGame, Is.EqualTo(infoPageTopGame));
    }
}
