namespace Task3;

public class TestCase1 : BaseTest
{
    [Test]
    public void Test()
    {
        Logger.LogInfo("Первый тест-кейс");
        Logger.LogInfo("Перейти на главную страницу.");
        var mainPage = new MainPage();
        Assert.That(mainPage.IsOpened);

        mainPage.ClickAlertsFrameWindows();
        var menuPage = new MenuPage();
        menuPage.ClickAlertsTab();
        var alertsPage = new AlertsPage();
        Assert.That(alertsPage.IsOpened());

        alertsPage.ClickToAlertButton();
        Assert.That(AlertsUtils.GetAlertText(), Is.EqualTo(DataUtility.GetTestData.TestData.AlertText));

        AlertsUtils.AcceptAlert();
        Assert.That(!AlertsUtils.IsExistAlert());

        alertsPage.ClickConfirmBoxButton();
        Assert.That(AlertsUtils.GetAlertText(), Is.EqualTo(DataUtility.GetTestData.TestData.AlertConfirmText));

        AlertsUtils.AcceptAlert();
        Assert.That(!AlertsUtils.IsExistAlert());
        Assert.That(alertsPage.GetConfirmText(), Is.EqualTo(DataUtility.GetTestData.TestData.ConfirmBoxText));

        alertsPage.ClickPromptBoxButton();
        Assert.That(AlertsUtils.GetAlertText(), Is.EqualTo(DataUtility.GetTestData.TestData.PromptText));

        Logger.LogInfo("Ввести случайно сгенерированный текст");
        var randomString = RandomGenerate.GetRandomString();
        AlertsUtils.InputTextAlert(randomString);
        AlertsUtils.AcceptAlert();
        Assert.That(alertsPage.GetPromptText(), Is.EqualTo($"You entered {randomString}"));
        Assert.That(!AlertsUtils.IsExistAlert());
    }
}
