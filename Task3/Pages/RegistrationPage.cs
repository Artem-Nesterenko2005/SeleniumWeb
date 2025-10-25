using OpenQA.Selenium;

namespace Task3;

public class RegistrationPage : BasePage
{
    private InputElement firstNameInput = new(By.XPath("//input[@id = 'firstName']"), "First name");

    private InputElement lastNameInput = new(By.XPath("//input[@id = 'lastName']"), "Last name");

    private InputElement emailInput = new(By.XPath("//input[@id = 'userEmail']"), "Email");

    private InputElement ageInput = new(By.XPath("//input[@id = 'age']"), "Age");

    private InputElement salaryInput = new(By.XPath("//input[@id = 'salary']"), "Salary");

    private InputElement departmentInput = new(By.XPath("//input[@id = 'department']"), "Department");

    private ButtonElement submitButton = new(By.XPath("//button[@id = 'submit']"), "Submit");

    public static int recordIndex { get; private set; }

    private const int rowNumbers = 10;

    private const int columnNumbers = 7;

    public RegistrationPage() : base(By.XPath("//*[contains(@class,'modal-content')]"), "Registration form")
    {
    }

    private void InputFirstName(string text) => firstNameInput.InputText(text);

    private void InputLastName(string text) => lastNameInput.InputText(text);

    private void InputEmail(string text) => emailInput.InputText(text);

    private void InputAge(string text) => ageInput.InputText(text);

    private void InputSalary(string text) => salaryInput.InputText(text);

    private void InputDepartment(string text) => departmentInput.InputText(text);

    public void FillUserInfo(string firstName, string lastName, string email, string age, string salary, string department)
    {
        InputFirstName(firstName);
        InputLastName(lastName);
        InputEmail(email);
        InputAge(age);
        InputSalary(salary);
        InputDepartment(department);
    }

    public void ClickSubmitButton() => submitButton.Click();

    public List<UserModel> GetRegistrationFormInfo()
    {
        var result = new List<UserModel>();
        var firstName = string.Empty;
        var lastName = string.Empty;
        var age = 0;
        var email = string.Empty;
        var salary = 0;
        var department = string.Empty;
        for (var i = 1; i < rowNumbers; ++i)
        {
            for (var t = 1; t < columnNumbers; ++t)
            {
                var row = SingleDriver.GetDriver.FindElement(By.XPath($"//*[@class='rt-tr-group'][{i}]//*[contains(@class,'rt-td')][{t}]"));
                switch (t)
                {
                    case 1:
                        if (row.Text == " ")
                        {
                            recordIndex = i - 1;
                            return result;
                        }
                        firstName = row.Text;
                        break;

                    case 2:
                        lastName = row.Text;
                        break;

                    case 3:
                        age = int.Parse(row.Text);
                        break;

                    case 4:
                        email = row.Text;
                        break;

                    case 5:
                        salary = int.Parse(row.Text);
                        break;

                    case 6:
                        department = row.Text;
                        result.Add(new UserModel(firstName, lastName, email, age, salary, department));
                        break;
                }
            }
        }
        return result;
    }
}
