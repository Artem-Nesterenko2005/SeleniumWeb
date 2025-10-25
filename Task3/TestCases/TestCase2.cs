namespace Task3;

public class TestCase2 : BaseTest
{
    [Test]
    public void Test()
    {
        Logger.LogInfo("Второй тест-кейс");
        Logger.LogInfo("Перейти на главную страницу.");
        var mainPage = new MainPage();
        Assert.That(mainPage.IsOpened);

        mainPage.ClickAlertsFrameWindows();
        var menuPage = new MenuPage();

        menuPage.ClickNestedFramesTab();
        var nestedFramesPage = new NestedFramesPage();
        Assert.That(nestedFramesPage.IsOpened());
        Assert.That(nestedFramesPage.GetParentFrameText(), Is.EqualTo(DataUtility.GetTestData.TestData.ParentFrameText));
        Assert.That(nestedFramesPage.GetChildFrameText(), Is.EqualTo(DataUtility.GetTestData.TestData.ChildFrameText));

        menuPage.ClickFramesTab();
        var framesPage = new FramesPage();
        Assert.That(framesPage.IsOpened());
        Assert.That(framesPage.GetChildFrameText(), Is.EqualTo(framesPage.GetParentFrameText()));
    }
}
