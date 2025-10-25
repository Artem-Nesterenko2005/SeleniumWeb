using NUnit.Framework.Internal;

namespace Task3;

public class TestCase3 : BaseTest
{
    private static IEnumerable<TestCaseData> GetUserDataTestCases()
    {
        foreach (var user in DataUtility.GetTestData.UserModel)
        {
            yield return new TestCaseData(user);
        }
    }

    [Test]
    [TestCaseSource(nameof(GetUserDataTestCases))]
    public void Test(UserModel userInfo)
    {
        Logger.LogInfo("Третий тест-кейс");
        Logger.LogInfo("Перейти на главную страницу.");
        var mainPage = new MainPage();
        Assert.That(mainPage.IsOpened);

        mainPage.ClickElementsButton();
        var menuPage = new MenuPage();
        menuPage.ClickWebElementsButton();
        var webTablesPage = new WebTablesPage();
        Assert.That(webTablesPage.IsOpened());

        webTablesPage.ClickAddButton();
        var registrationForm = new RegistrationPage();
        Assert.That(registrationForm.IsOpened());

        Logger.LogInfo("Ввести данные пользователя");
        registrationForm.FillUserInfo(userInfo.FirstName, userInfo.LastName, userInfo.Email, 
            userInfo.Age.ToString(), userInfo.Salary.ToString(), userInfo.Department);
        registrationForm.ClickSubmitButton();

        var users = registrationForm.GetRegistrationFormInfo();
        Assert.That(!registrationForm.IsOpened());
        var newUser = users[users.Count - 1];
        Assert.That(newUser, Is.EqualTo(userInfo));

        var recordsNumber = users.Count;
        webTablesPage.DeleteRecord();
        var usersAfterDelete = registrationForm.GetRegistrationFormInfo();
        var newRecordsNumber = usersAfterDelete.Count;
        Assert.That(recordsNumber, !Is.EqualTo(newRecordsNumber));
        Assert.That(newUser, !Is.EqualTo(usersAfterDelete[usersAfterDelete.Count - 1]));
    }
}
