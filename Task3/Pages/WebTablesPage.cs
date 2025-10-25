using OpenQA.Selenium;

namespace Task3;

public class WebTablesPage : BasePage
{
    private ButtonElement addButton = new(By.XPath("//button[@id = 'addNewRecordButton']"), "Add");

    public WebTablesPage() : base(By.XPath("//*[contains(@class,'text-center') and contains(text(), 'Tables')]"), "Web tables page")
    {
    }

    public void ClickAddButton() => addButton.Click();

    public void DeleteRecord()
    {
        var deleteButton = new ButtonElement(By.XPath($"//*[@id = 'delete-record-{RegistrationPage.recordIndex}']"), "Delete");
        deleteButton.Click();
    }
}
