namespace Task3;

public class TestCase4 : BaseTest
{
    [Test]
    public void Test()
    {
        Logger.LogInfo("Четвертый тест-кейс");
        Logger.LogInfo("Перейти на главную страницу.");
        var mainPage = new MainPage();
        Assert.That(mainPage.IsOpened);

        mainPage.ClickAlertsFrameWindows();
        var menuPage = new MenuPage();
        menuPage.ClickBrowserWindowsTab();
        var browserWindowsPage = new BrowserWindowsPage();
        Assert.That(browserWindowsPage.IsOpened);

        browserWindowsPage.ClickAddTabButton();
        TabsUtils.SwitchTab();
        var samplePage = new SamplePage();
        Assert.That(samplePage.IsOpened());

        Logger.LogInfo("Закрыть текущую вкладку");
        TabsUtils.CloseTab();
        TabsUtils.SwitchMainTab();
        Assert.That(browserWindowsPage.IsOpened);

        menuPage.ClickElementsButton();
        menuPage.ClickLinksButton();
        var linksPage = new LinksPage();
        Assert.That(linksPage.IsOpened);

        linksPage.ClickHomeLink();
        TabsUtils.SwitchTab();
        Assert.That(mainPage.IsOpened);

        Logger.LogInfo("Переключиться на прошлую вкладку");
        TabsUtils.SwitchMainTab();
        Assert.That(linksPage.IsOpened);
    }
}
